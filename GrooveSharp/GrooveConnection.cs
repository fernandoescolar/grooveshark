using System.Collections.Generic;
using System.Linq;
using GrooveSharp.DataTransferObjects;
using GrooveSharp.Protocol;
using GrooveSharp.Protocol.Commands;

namespace GrooveSharp
{
    public class GrooveConnection : IGrooveConnection
    {
        private readonly ISession session;
        private readonly IAsyncCommandFactory commandFactory;

        public GrooveConnection(ISession session, IAsyncCommandFactory commandFactory)
        {
            session.PrepareEnviroment();
            this.session = session;
            this.commandFactory = commandFactory;
        }

        public IAsyncCommand<bool> Open()
        {
            var innerCommand = this.GetCommunicationToken();
            var command = this.commandFactory.Create(innerCommand, GetCommunicationTokenHandler);

            return command;
        }

        public IAsyncCommand<bool> Authenticate(string username, string password)
        {
            var innerCommand = this.AuthenicateUser(username, password);
            var command = this.commandFactory.Create(innerCommand, AuthenticateUserHandler);

            return command;
        }

        public IAsyncCommand<bool> InitiateQueue()
        {
            var innerCommand = this.commandFactory.Create<DummyStreamData, string>("initiateQueue");
            var command = this.commandFactory.Create(innerCommand, InitiateQueueHandler);

            return command;
        }


        public IAsyncCommand<SearchResult> GetResultsFromSearch(string queryString)
        {
            return GetResultsFromSearch(queryString, SearchType.Songs | SearchType.Albums | SearchType.Artists);
        }

        public IAsyncCommand<SearchResult> GetResultsFromSearch(string queryString, SearchType type)
        {
            var command = this.commandFactory.Create<ResultsFromSearchRequest, SearchResult>("getResultsFromSearch");
            command.Parameters.Guts = "1";
            command.Parameters.Query = queryString;
            command.Parameters.Type = type;

            return command;
        }

        public IAsyncCommand<SearchResultSet> GetPopularSongs(PopularSongsRequestType type)
        {
            var command = this.commandFactory.Create<PopularSongsRequest, SearchResultSet>("popularGetSongs");
            command.Parameters.Type = type;

            return command;
        }

        public IAsyncCommand<PlaylistCollection> GetUserPlaylists()
        {
            var command = this.commandFactory.Create<UserPlayListRequest, PlaylistCollection>("userGetPlaylists");
            command.Parameters.UserId = this.session.User.UserId;

            return command;
        }

        public IAsyncCommand<SongCollection> GetPlaylistSongs(int playlistId)
        {
            var command = this.commandFactory.Create<PlaylistSongsRequest, SongCollection>("playlistGetSongs");
            command.Parameters.PlaylistId = playlistId;

            return command;
        }

        public IAsyncCommand<int> CreatePlaylist(string name, string about)
        {
            return this.CreatePlaylist(name, about, new List<int>());
        }

        public IAsyncCommand<int> CreatePlaylist(string name, string about, IEnumerable<int> songIds)
        {
            var command = this.commandFactory.Create<CreatePlaylistRequest, int>("createPlaylist");
            command.Parameters.Name = name;
            command.Parameters.About = about;
            command.Parameters.SongIds = songIds.ToList();

            return command;
        }

        public IAsyncCommand<int> DeletePlaylist(int playlistId, string name)
        {
            var command = this.commandFactory.Create<DeletePlaylistRequest, int>("deletePlaylist");
            command.Parameters.Name = name;
            command.Parameters.PlaylistId = playlistId;

            return command;
        }

        public IAsyncCommand<StreamInfo> GetStreamKeyFromSongId(string songId)
        {
            var command = this.commandFactory.Create<StreamKeyFromSongId, StreamInfo>("getStreamKeyFromSongIDEx");
            command.Parameters.Country = this.session.Country;
            command.Parameters.Mobile = false;
            command.Parameters.Type = 8;
            command.Parameters.SongId = songId;
            command.Parameters.Prefetch = false;

            return command;
        }

        /// <summary>
        /// It's not working and i don't know why. To avoid being banned you should call this before download a song.
        /// </summary>
        public IAsyncCommand<object> MarkSongAsDownloaded(string songId, string streamServerId, string streamKey)
        {
            var command = this.commandFactory.Create<DownloadInfo, object>("markSongAsDownloadedEx");
            command.Parameters.StreamServerId = streamServerId;
            command.Parameters.StreamKey = streamKey;
            command.Parameters.SongId = int.Parse(songId);

            return command;
        }

        public IAsyncCommand<bool> AddSongsToQueue(string songId, string artistId)
        {
            var command = this.commandFactory.Create<AddToQueueRequest, bool>("addSongsToQueue");
            command.Parameters.SongIDsArtistIDs = new [] { new SongAndArtist
                                                            {
                                                                ArtistId = artistId,
                                                                SongId = songId,
                                                                Source = "user",
                                                                SongQueueSongId = 1
                                                            }};
            command.Parameters.SongQueueId = this.session.Queue;

            return command;
        }

        public IAsyncCommand<bool> RemoveSongsFromQueue()
        {
            var command = this.commandFactory.Create<RemoveFromQueueRequest, bool>("removeSongsFromQueue");
            command.Parameters.UserRemoved = true;
            command.Parameters.SongQueueId = this.session.Queue;
            command.Parameters.SongQueueSongIDs = new[]{ 1 };

            return command;
        }

        public IAsyncCommand<GrooveStream> DownloadSong(StreamInfo streamInfo)
        {
            var command = this.commandFactory.Download(streamInfo);

            return command;
        }

        public IAsyncCommand<object> MarkStreamKeyOver30Seconds(string songId, string artistId, string streamServerId, string streamKey)
        {
            var command = this.commandFactory.Create<MarkOver30SecondsRequest, object>("markStreamKeyOver30Seconds");
            command.Parameters.StreamServerId = streamServerId;
            command.Parameters.StreamKey = streamKey;
            command.Parameters.SongId = int.Parse(songId);
            command.Parameters.ArtistId = int.Parse(artistId);
            command.Parameters.SongQueueId = this.session.Queue;
            command.Parameters.SongQueueSongId = 1;

            return command;
        }

        private IAsyncCommand<string> GetCommunicationToken()
        {
            var command = this.commandFactory.Create<ComunicationTokenRequest, string>("getCommunicationToken");
            command.Parameters.SecretKey = this.session.SecretKey;

            return command;
        }

        private IAsyncCommand<User> AuthenicateUser(string username, string password)
        {
            var command = this.commandFactory.Create<AuthenticateUserRequest, User>("authenticateUser");
            command.Parameters.Username = username;
            command.Parameters.Password = password;
            command.Parameters.SavePassword = "0";

            return command;
        }

        private bool GetSessionIdHandler(string sessionId)
        {
            if (!string.IsNullOrEmpty(sessionId))
            {
                this.session.Initialize(sessionId);
                return true;
            }

            return false;
        }

        private bool GetCommunicationTokenHandler(string token)
        {
            if (token != null)
            {
                this.session.SetSessionToken(token);
                return true;
            }

            return false;
        }

        private bool AuthenticateUserHandler(User user)
        {
            if (user != null && user.UserId > 0)
            {
                this.session.SetUser(user);
                return true;
            }

            this.session.SetNoUser();
            return false;
        }

        private bool InitiateQueueHandler(string queue)
        {
            if (!string.IsNullOrEmpty(queue))
            {
                this.session.SetQueue(queue);
                return true;
            }

            return false;
        }
    }
}
