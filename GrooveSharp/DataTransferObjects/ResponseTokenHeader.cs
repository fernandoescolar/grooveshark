using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    internal class ResponseTokenHeader
    {
        [DataMember(Name = "expiredClient")]
        public bool ExpiredClient { get; set; }

        [DataMember(Name = "session")]
        public string SessionId { get; set; }

        [DataMember(Name = "serviceVersion")]
        public string ServiceVersion { get; set; }

        [DataMember(Name = "prefetchEnabled")]
        public bool PrefetchEnabled { get; set; }
    }
}