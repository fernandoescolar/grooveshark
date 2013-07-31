using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    internal class RequestTokenHeader
    {
        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "country")]
        public Country Country { get; set; }

        [DataMember(Name = "session")]
        public string SessionId { get; set; }

        [DataMember(Name = "clientRevision")]
        public string ClientRevision { get; set; }

        [DataMember(Name = "privacy")]
        public int Privacy { get; set; }

        [DataMember(Name = "client")]
        public string Client { get; set; }

        [DataMember(Name = "uuid")]
        public string Uuid { get; set; }
    }
}