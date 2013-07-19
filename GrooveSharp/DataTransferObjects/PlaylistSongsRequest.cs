using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    internal class PlaylistSongsRequest
    {
        [DataMember(Name = "playlistID")]
        public int PlaylistId { get; set; }
    }
}
