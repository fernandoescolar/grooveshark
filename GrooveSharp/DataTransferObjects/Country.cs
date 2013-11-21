using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    public class Country
    {
        [DataMember(Name = "ID")]
        public string Id { get; set; }

        [DataMember(Name = "CC1")]
        public string Cc1 { get; set; }

        [DataMember(Name = "CC2")]
        public string Cc2 { get; set; }

        [DataMember(Name = "CC3")]
        public string Cc3 { get; set; }

        [DataMember(Name = "CC4")]
        public string Cc4 { get; set; }

        [DataMember(Name = "DMA")]
        public int Dma { get; set; }

        [DataMember(Name = "IPR")]
        public string Ipr { get; set; }
    }
}