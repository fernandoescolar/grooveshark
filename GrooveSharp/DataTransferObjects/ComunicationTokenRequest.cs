using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    [UseSsl]
    internal class ComunicationTokenRequest
    {
        [DataMember(Name = "secretKey")]
        public string SecretKey { get; set; }
    }
}
