using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public enum PopularSongsRequestType
    {
        [EnumMember(Value = "daily")]
        Daily,

        [EnumMember(Value = "weekly")]
        Weekly,

        [EnumMember(Value = "monthly")]
        Monthly
    }
}