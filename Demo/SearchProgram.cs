using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GrooveSharp.DataTransferObjects;
using StructureMap;

namespace GrooveSharp.Demo
{
    public class SearchProgram
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

            Console.WriteLine("Type search: ");
            var search = Console.ReadLine();

            DonwloadSearch(search);

            Console.WriteLine("Done! ");
            Console.ReadLine();
        }

        private static async void DonwloadSearch(string search)
        {
            await con.Open().ExecuteAsync();

            var result = await con.GetResultsFromSearch(search).ExecuteAsync();

            var song = result.ResultSet.Songs.Select(r => new Song{ AlbumId = r.AlbumId, AlbumName = r.AlbumName, ArtistId = r.ArtistId, ArtistName = r.ArtistName, SongId = r.SongId, Name = r.SongName}).FirstOrDefault();
            if (song != null)
            {
                var filename = GetDownloadFilePath(song);
                await DownloadSong(song, filename);
            }
        }

        private static async Task DownloadSong(Song song, string filename)
        {
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

                return;
            }

            var stream = await con.DownloadSong(streamInfo).ExecuteAsync();

            using (var reader = new BinaryReader(stream))
            {
                try
                {
                    using (new Timer(Mark30SecondsCallback, new object[] { streamInfo, song },TimeSpan.FromSeconds(30).Milliseconds, -1))
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

                    await con.MarkSongAsDownloaded(song.SongId, streamInfo.Ip, streamInfo.StreamKey).ExecuteAsync();
                    Console.WriteLine("\nCompleted: " + filename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Downloading: " + song + " - " + ex.Message);
                }
            }
        }

        private static void Mark30SecondsCallback(object state)
        {
            var streamInfo = (StreamInfo)((object[])state)[0];
            var song = (Song)((object[])state)[1];

            con.MarkStreamKeyOver30Seconds(song.SongId, song.ArtistId, streamInfo.Ip, streamInfo.StreamKey).ExecuteAsync();
        }

        public static string GetFilePath(Song song)
        {
            return song.ToString().Replace("\"", "").Replace("/", "").Replace("?", "").Replace(":", "").Trim() + ".mp3";
        }

        public static string GetDownloadFilePath(Song song)
        {
            return Path.Combine(downloadPath, GetFilePath(song));
        }
    }
}
