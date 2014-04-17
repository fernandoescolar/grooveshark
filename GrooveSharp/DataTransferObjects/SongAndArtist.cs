using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class SongAndArtist
    {
        [DataMember(Name = "artistID")]
        public int ArtistId { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "songID")]
        public int SongId { get; set; }

        [DataMember(Name = "songQueueSongID")]
        public int SongQueueSongId { get; set; }
    }
}