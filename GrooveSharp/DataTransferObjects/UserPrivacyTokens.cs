using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class UserPrivacyTokens
    {
        [DataMember(Name = "authenticated")]
        public string Authenticated { get; set; }

        [DataMember(Name = "unauthenticated")]
        public string Unauthenticated { get; set; }
    }
}