using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    [StreamCommand]
    public class DownloadInfo
    {
        [DataMember(Name = "streamKey")]
        public string StreamKey { get; set; }

        [DataMember(Name = "streamServerID")]
        public string StreamServerId { get; set; }

        [DataMember(Name = "songID")]
        public int SongId { get; set; }
    }
}