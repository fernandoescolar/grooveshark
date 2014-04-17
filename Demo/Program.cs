using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GrooveSharp.DataTransferObjects;
using StructureMap;

namespace GrooveSharp.Demo
{
    public class Program
    {
        private static IGrooveConnection con;
        private static readonly string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

        public static void Main(string[] args)
        {
            ObjectFactory.Initialize(x => x.Scan(cfg =>
                                                     {
                                                         cfg.TheCallingAssembly();
                                                         cfg.AssemblyContainingType<IGrooveConnection>();
                                                         cfg.LookForRegistries();
                                                     }));

            con = ObjectFactory.GetInstance<IGrooveConnection>();

            Console.WriteLine("Groovesark user name:");
            var username = Console.ReadLine();

            Console.WriteLine("password:");
            var password = GetPassword();

            DownloadAll(username, password);


            Console.ReadLine();
        }

        public static string GetPassword()
        {
            var pwd = new StringBuilder();
            while (true)
            {
                var i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("");
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    pwd.Remove(pwd.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else
                {
                    pwd.Append(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd.ToString();
        }

        public static bool MoveFileIfExists(string filename, string targetFilename)
        {
            if (File.Exists(filename))
            {
                File.Copy(filename, targetFilename, true);
                return true;
            }

            return false;
        }

        public static string GetFilePath(Song song)
        {
            return song.ToString().Replace("\"", "").Replace("/", "").Replace("?", "").Replace(":", "").Trim() + ".mp3";
        }

        public static string GetFilePath(Playlist playlist, Song song)
        {
            return Path.Combine(playlist.Name, GetFilePath(song));
        }

        public static string GetDownloadFilePath(Playlist playlist, Song song)
        {
            return Path.Combine(downloadPath, GetFilePath(playlist, song));
        }

        public static async void DownloadAll(string username, string password)
        {
            if (await InitializeAndLogin(username, password))
            {
                await DownloadAllPlaylistSongs();
            }

            Console.WriteLine("Finish");
        }

        private static async Task<bool> InitializeAndLogin(string username, string password)
        {
            var loggedin = false;
            var opened = await con.Open().ExecuteAsync();
            Console.WriteLine(opened ? "Connected" : "Not connected!");

            if (opened)
            {
                loggedin = await con.Authenticate(username, password).ExecuteAsync();
                Console.WriteLine(loggedin ? "Authenticated" : "Unauthenticated!");
                if (loggedin)
                {
                    var result = await con.InitiateQueue().ExecuteAsync();
                }
            }

            return loggedin;
        }

        private static async Task DownloadAllPlaylistSongs()
        {
            foreach (var playlist in await con.GetUserPlaylists().ExecuteAsync())
            {
                Console.WriteLine(playlist.Name);
                await DownloadAllPlaylistSongs(playlist);
            }
        }

        private static async Task DownloadAllPlaylistSongs(Playlist playlist)
        {
            foreach (var song in await con.GetPlaylistSongs(playlist.PlaylistId).ExecuteAsync())
            {
                Console.WriteLine("  - " + song);
                var filename = GetDownloadFilePath(playlist, song);
                CheckFileFolder(filename);

                try
                {
                    if (File.Exists(filename))
                    {
                        Console.WriteLine("    Skipped");
                    }
                    else
                    {
                        await DownloadSong(song, filename);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + song + " - " + ex.Message);
                }
            }
        }

        private static int queueSongId = 0;
        private static async Task DownloadSong(Song song, string filename)
        {
            queueSongId++;
            var added = await con.AddSongsToQueue(song.SongId, song.ArtistId, queueSongId).ExecuteAsync();
            var streamInfo = await con.GetStreamKeyFromSongId(song.SongId).ExecuteAsync();

            Console.WriteLine("StreamKey = " + streamInfo.StreamKey);
            Console.WriteLine("IP = " + streamInfo.Ip);
            Console.WriteLine("Url = " + streamInfo.StreamUrl);

            if (string.IsNullOrEmpty(streamInfo.StreamKey))
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not download, maybe you have been banned. Try it again in an hour...");
                Console.ForegroundColor = color;

                if (added)
                {
                    await con.RemoveSongsFromQueue(queueSongId).ExecuteAsync();
                }

                return;
            }

            var stream = await con.DownloadSong(streamInfo).ExecuteAsync();
            await con.MarkSongAsDownloaded(song.SongId, streamInfo.Ip, streamInfo.StreamKey).ExecuteAsync();
            await con.MarkQueueSongPlayed(song.SongId, streamInfo.Ip, streamInfo.StreamKey, queueSongId).ExecuteAsync();
            using (var reader = new BinaryReader(stream))
            {
                try
                {
                    using (
                        new Timer(Mark30SecondsCallback, new object[] {streamInfo, song},
                            TimeSpan.FromSeconds(30).Milliseconds, -1))
                    {
                        using (var writter = new BinaryWriter(File.OpenWrite(filename)))
                        {
                            var buffer = new byte[2048];
                            var read = 0;
                            while ((read = reader.Read(buffer, 0, 2048)) > 0)
                            {
                                writter.Write(buffer, 0, read);
                                Console.Write(".");
                            }
                        }
                    }

                   
                    Console.WriteLine("\nCompleted: " + filename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Downloading: " + song + " - " + ex.Message);
                }
                finally
                {
                    if (added)
                    {
                        con.RemoveSongsFromQueue(queueSongId).ExecuteAsync();
                    }
                }
            }
        }

        private static void Mark30SecondsCallback(object state)
        {
            var streamInfo = (StreamInfo)((object[])state)[0];
            var song = (Song)((object[])state)[1];
            
            con.MarkStreamKeyOver30Seconds(song.SongId, song.ArtistId, streamInfo.Ip, streamInfo.StreamKey).ExecuteAsync();
        }

        private static void CheckFileFolder(string filename)
        {
            var folder = Path.GetDirectoryName(filename);

            if (folder != null && !Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}
