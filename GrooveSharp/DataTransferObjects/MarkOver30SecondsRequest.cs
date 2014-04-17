using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    [StreamCommand]
    public class MarkOver30SecondsRequest
    {
        [DataMember(Name = "streamKey")]
        public string StreamKey { get; set; }

        [DataMember(Name = "streamServerID")]
        public string StreamServerId { get; set; }

        [DataMember(Name = "artistID")]
        public int ArtistId { get; set; }

        [DataMember(Name = "songID")]
        public int SongId { get; set; }

        [DataMember(Name = "songQueueSongID")]
        public int SongQueueSongId { get; set; }

        [DataMember(Name = "songQueueID")]
        public string SongQueueId { get; set; }
    }
}
