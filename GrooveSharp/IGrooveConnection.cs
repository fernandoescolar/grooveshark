using System.Collections.Generic;
using GrooveSharp.DataTransferObjects;
using GrooveSharp.Protocol.Commands;

namespace GrooveSharp.DataTransferObjects
{
}

namespace GrooveSharp
{
    public interface IGrooveConnection
    {
        IAsyncCommand<bool> Open();
        IAsyncCommand<bool> Authenticate(string username, string password);
        IAsyncCommand<bool> InitiateQueue();

        IAsyncCommand<SearchResult> GetResultsFromSearch(string queryString);
        IAsyncCommand<SearchResult> GetResultsFromSearch(string queryString, SearchType type);

        IAsyncCommand<SearchResultSet> GetPopularSongs(PopularSongsRequestType type);

        IAsyncCommand<PlaylistCollection> GetUserPlaylists();
        IAsyncCommand<SongCollection> GetPlaylistSongs(int playlistId);
        IAsyncCommand<int> CreatePlaylist(string name, string about);
        IAsyncCommand<int> CreatePlaylist(string name, string about, IEnumerable<int> songIds);
        IAsyncCommand<int> DeletePlaylist(int playlistId, string name);

        IAsyncCommand<StreamInfo> GetStreamKeyFromSongId(string songId);
        IAsyncCommand<object> MarkSongAsDownloaded(string songId, string streamServerId, string streamKey);
        IAsyncCommand<bool> AddSongsToQueue(string songId, string artistId, int queueSongId);
        IAsyncCommand<bool> RemoveSongsFromQueue(int queueSongId);
        IAsyncCommand<object> MarkQueueSongPlayed(string songId, string streamServerId, string streamKey, int queueSongId);
        IAsyncCommand<GrooveStream> DownloadSong(StreamInfo streamInfo);
        IAsyncCommand<object> MarkStreamKeyOver30Seconds(string songId, string artistId, string streamServerId, string streamKey);
    }
}
