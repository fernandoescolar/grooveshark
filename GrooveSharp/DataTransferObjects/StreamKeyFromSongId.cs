using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    [StreamCommand]
    internal class StreamKeyFromSongId
    {
        [DataMember(Name = "country")]
        public Country Country { get; set; }

        [DataMember(Name = "mobile")]
        public bool Mobile { get; set; }

        [DataMember(Name = "type")]
        public int Type { get; set; }

        [DataMember(Name = "songID")]
        public string SongId { get; set; }

        [DataMember(Name = "prefetch")]
        public bool Prefetch { get; set; }
    }
}
