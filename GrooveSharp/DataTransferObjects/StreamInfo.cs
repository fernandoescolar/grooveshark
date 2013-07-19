using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class StreamInfo
    {
        [DataMember(Name = "FileID")]
        public string FileId { get; set; }

        [DataMember(Name = "uSecs")]
        public string USecs { get; set; }

        [DataMember(Name = "FileToken")]
        public string FileToken { get; set; }

        [DataMember(Name = "ts")]
        public int TimeSpan { get; set; }

        [DataMember(Name = "isMobile")]
        public bool IsMobile { get; set; }

        [DataMember(Name = "streamKey")]
        public string StreamKey { get; set; }

        [DataMember(Name = "StreamServerID")]
        public int StreamServerId { get; set; }

        [DataMember(Name = "ip")]
        public string Ip { get; set; }

        public string StreamUrl { get { return string.Format("http://{0}/stream.php", this.Ip); } }
    }
}
