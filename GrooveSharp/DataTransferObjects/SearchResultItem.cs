using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    public class SearchResultItem
    {
        [DataMember(Name = "SongID")]
        public string SongId { get; set; }

        [DataMember(Name = "AlbumID")]
        public string AlbumId { get; set; }

        [DataMember(Name = "ArtistID")]
        public string ArtistId { get; set; }

        [DataMember(Name = "GenreID")]
        public string GenreId { get; set; }

        [DataMember(Name = "SongName")]
        public string SongName { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "AlbumName")]
        public string AlbumName { get; set; }

        [DataMember(Name = "ArtistName")]
        public string ArtistName { get; set; }

        [DataMember(Name = "Year")]
        public string Year { get; set; }

        [DataMember(Name = "TrackNum")]
        public string TrackNum { get; set; }

        [DataMember(Name = "CoverArtFilename")]
        public string CoverArtFilename { get; set; }

        [DataMember(Name = "ArtistCoverArtFilename")]
        public string ArtistCoverArtFilename { get; set; }

        [DataMember(Name = "TSAdded")]
        public long TimeSpanAdded { get; set; }

        [DataMember(Name = "AvgRating")]
        public double? Rating { get; set; }

        [DataMember(Name = "EstimateDuration")]
        public double? EstimateDuration { get; set; }

        [DataMember(Name = "Flags")]
        public string Flags { get; set; }

        [DataMember(Name = "IsLowBitrateAvailable")]
        public int IsLowBitrateAvailable { get; set; }

        [DataMember(Name = "IsVerified")]
        public int IsVerified { get; set; }

        [DataMember(Name = "Popularity")]
        public long Popularity { get; set; }

        [DataMember(Name = "Score")]
        public double? Score { get; set; }

        [DataMember(Name = "RawScore")]
        public int RawScore { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", ArtistName, string.IsNullOrEmpty(SongName) ? Name : SongName);
        }
    }
}