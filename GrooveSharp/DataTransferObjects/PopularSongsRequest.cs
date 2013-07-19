using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    internal class PopularSongsRequest
    {
        [DataMember(Name = "type")]
        public PopularSongsRequestType Type { get; set; }
    }
}
