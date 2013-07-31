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
        IAsyncCommand<bool> Initialize();
        IAsyncCommand<bool> Open();
        IAsyncCommand<bool> Authenticate(string username, string password);

        IAsyncCommand<SearchResult> GetResultsFromSearch(string queryString);
        IAsyncCommand<SearchResult> GetResultsFromSearch(string queryString, SearchType type);

        IAsyncCommand<SearchResultSet> GetPopularSongs(PopularSongsRequestType type);

        IAsyncCommand<PlaylistCollection> GetUserPlaylists();
        IAsyncCommand<SongCollection> GetPlaylistSongs(int playlistId);
        IAsyncCommand<int> CreatePlaylist(string name, string about);
        IAsyncCommand<int> CreatePlaylist(string name, string about, IEnumerable<int> songIds);
        IAsyncCommand<int> DeletePlaylist(int playlistId, string name);

        IAsyncCommand<StreamInfo> GetStreamKeyFromSongId(string songId);
        IAsyncCommand<DownloadInfo> MarkSongAsDownloaded(string songId, string streamServerId, string streamKey);
        IAsyncCommand<GrooveStream> DownloadSong(StreamInfo streamInfo);
        IAsyncCommand<object> MarkSongAsComplete(string songId, string streamServerId, string streamKey);
    }
}
