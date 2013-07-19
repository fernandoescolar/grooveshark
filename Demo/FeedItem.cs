using System;
using System.Runtime.Serialization;

namespace GrooveSharp.Demo
{
    [DataContract]
    public class FeedItem : IEquatable<FeedItem>
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public DateTime PublishDate { get; set; }

        public bool Equals(FeedItem other)
        {
            return this.Title.Equals(other.Title);
        }
    }
}