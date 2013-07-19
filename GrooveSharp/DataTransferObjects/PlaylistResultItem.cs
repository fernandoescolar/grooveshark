using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class PlaylistResultItem
    {
        [DataMember(Name = "About")]
        public string About { get; set; }

        [DataMember(Name = "Artists")]
        public string Artists { get; set; }

        [DataMember(Name = "FName")]
        public string FName { get; set; }

        [DataMember(Name = "IsDeleted")]
        public string IsDeleted { get; set; }

        [DataMember(Name = "LName")]
        public string LName { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "NumArtists")]
        public string NumArtists { get; set; }

        [DataMember(Name = "NumSongs")]
        public string NumSongs { get; set; }

        [DataMember(Name = "Picture")]
        public string Picture { get; set; }

        [DataMember(Name = "PlaylistID")]
        public string PlaylistId { get; set; }

        [DataMember(Name = "Score")]
        public double Score { get; set; }

        [DataMember(Name = "SphinxSortExpr")]
        public int SphinxSortExpr { get; set; }

        [DataMember(Name = "TSAdded")]
        public string TimeSpanAdded { get; set; }

        [DataMember(Name = "UserID")]
        public string UserId { get; set; }

        [DataMember(Name = "Username")]
        public string Username { get; set; }
    }
}
