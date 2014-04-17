using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    [StreamCommand]
    public class RemoveFromQueueRequest
    {
        [DataMember(Name = "userRemoved")]
        public bool UserRemoved { get; set; }

        [DataMember(Name = "songQueueID")]
        public string SongQueueId { get; set; }

        [DataMember(Name = "songQueueSongIDs")]
        public int[] SongQueueSongIDs { get; set; }
    
    }
}
