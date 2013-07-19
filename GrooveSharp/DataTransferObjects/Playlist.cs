using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class Playlist
    {
        [DataMember(Name = "About")]
        public string About { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Picture")]
        public string Picture { get; set; }

        [DataMember(Name = "PlaylistID")]
        public int PlaylistId { get; set; }

        [DataMember(Name = "TSAdded")]
        public string TimeSpanAdded { get; set; }

        [DataMember(Name = "TSModified")]
        public int TimeSpanModified { get; set; }

        [DataMember(Name = "UUID")]
        public string Uuid { get; set; }

        [DataMember(Name = "UserID")]
        public int UserId { get; set; }
    }
}
