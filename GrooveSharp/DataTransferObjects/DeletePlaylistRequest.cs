using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    internal class DeletePlaylistRequest
    {
        [DataMember(Name = "playlistID")]
        public int PlaylistId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
