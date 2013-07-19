using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class SearchResultSet
    {
        [DataMember(Name = "Albums")]
        public List<SearchResultItem> Albums { get; set; }

        [DataMember(Name = "Artists")]
        public List<SearchResultItem> Artists { get; set; }

        [DataMember(Name = "Songs")]
        public List<SearchResultItem> Songs { get; set; }

        [DataMember(Name = "Playlists")]
        public List<PlaylistResultItem> Playlists { get; set; }

        [DataMember(Name = "Users")]
        public List<UserResultItem> Users { get; set; }

        [DataMember(Name = "Events")]
        public List<EventResultItem> Events { get; set; }

        [DataMember(Name = "assignedVersion")]
        public string AssignedVersion { get; set; }

        public SearchResultSet()
        {
            this.Albums = new List<SearchResultItem>();
            this.Artists = new List<SearchResultItem>();
            this.Songs = new List<SearchResultItem>();
            this.Playlists = new List<PlaylistResultItem>();
            this.Users = new List<UserResultItem>();
            this.Events = new List<EventResultItem>();
        }
    }
}
