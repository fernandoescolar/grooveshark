using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    [StreamCommand]
    public class AddToQueueRequest
    {
        [DataMember(Name = "songIDsArtistIDs")]
        public SongAndArtist[] SongIDsArtistIDs { get; set; }

        [DataMember(Name = "songQueueID")]
        public string SongQueueId { get; set; }

    }
}
