using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class EventResultItem
    {
        [DataMember(Name = "ArtistName")]
        public string ArtistName { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "EventName")]
        public string EventName { get; set; }

        [DataMember(Name = "GeoDist")]
        public int GeoDist { get; set; }

        [DataMember(Name = "Rank")]
        public string Rank { get; set; }

        [DataMember(Name = "SphinxSortExpr")]
        public int SphinxSortExpr { get; set; }

        [DataMember(Name = "StartTime")]
        public string StartTime { get; set; }

        [DataMember(Name = "TicketsURL")]
        public string TicketsUrl { get; set; }

        [DataMember(Name = "VenueName")]
        public string VenueName { get; set; }
    }
}
