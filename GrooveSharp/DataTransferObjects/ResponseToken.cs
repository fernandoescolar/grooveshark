using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    [DataContract]
    internal class ResponseToken<T>
    {
        [DataMember(Name = "header")]
        public ResponseTokenHeader Header { get; set; }

        [DataMember(Name = "result")]
        public T Result { get; set; }

        [DataMember(Name = "fault")]
        public Fault Fault { get; set; }

        public bool IsFaulted { get { return this.Fault != null; } }

        public ResponseToken()
        {
            this.Header = new ResponseTokenHeader();
        }
    }
}