using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    internal class UserPlayListRequest
    {
        [DataMember(Name = "userID")]
        public int UserId { get; set; }
    }
}
