using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    internal class CreatePlaylistRequest
    {
        [DataMember(Name = "playlistName")]
        public string Name { get; set; }

        [DataMember(Name = "playlistAbout")]
        public string About { get; set; }

        [DataMember(Name = "songIDs")]
        public List<int> SongIds { get; set; }

        public CreatePlaylistRequest()
        {
            this.SongIds = new List<int>();
        }
    }
}
