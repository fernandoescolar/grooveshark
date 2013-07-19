using System;
using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [Flags]
    [DataContract]
    public enum SearchType
    {
        None,
        [EnumMember(Value = "Songs")]
        Songs,
        [EnumMember(Value = "Albums")]
        Albums,
        [EnumMember(Value = "Artists")]
        Artists,
        [EnumMember(Value = "Playlists")]
        Playlists,
        [EnumMember(Value = "Users")]
        Users,
        [EnumMember(Value = "Events")]
        Events
    }
}