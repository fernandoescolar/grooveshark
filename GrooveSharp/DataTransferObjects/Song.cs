using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class Song
    {
        [DataMember(Name = "AlbumID")]
        public string AlbumId { get; set; }

        [DataMember(Name = "AlbumName")]
        public string AlbumName { get; set; }

        [DataMember(Name = "ArtistID")]
        public string ArtistId { get; set; }

        [DataMember(Name = "ArtistName")]
        public string ArtistName { get; set; }

        [DataMember(Name = "AvgRating")]
        public string AvgRating { get; set; }

        [DataMember(Name = "CoverArtFilename")]
        public string CoverArtFilename { get; set; }

        [DataMember(Name = "EstimateDuration")]
        public string EstimateDuration { get; set; }

        [DataMember(Name = "Flags")]
        public string Flags { get; set; }

        [DataMember(Name = "IsLowBitrateAvailable")]
        public string IsLowBitrateAvailable { get; set; }

        [DataMember(Name = "IsVerified")]
        public string IsVerified { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Popularity")]
        public string Popularity { get; set; }

        [DataMember(Name = "SongID")]
        public string SongId { get; set; }

        [DataMember(Name = "SongNameID")]
        public string SongNameId { get; set; }

        [DataMember(Name = "Sort")]
        public int Sort { get; set; }

        [DataMember(Name = "TrackNum")]
        public string TrackNum { get; set; }

        [DataMember(Name = "UserRating")]
        public string UserRating { get; set; }

        [DataMember(Name = "Year")]
        public string Year { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", ArtistName, Name);
        }
    }
}
