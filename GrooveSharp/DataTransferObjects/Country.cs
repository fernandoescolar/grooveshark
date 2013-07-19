using System.Runtime.Serialization;

namespace GrooveSharp.DataTransferObjects
{
    public class Country
    {
        [DataMember(Name = "ID")]
        public int Id { get; set; }

        [DataMember(Name = "CC1")]
        public int Cc1 { get; set; }

        [DataMember(Name = "CC2")]
        public int Cc2 { get; set; }

        [DataMember(Name = "CC3")]
        public int Cc3 { get; set; }

        [DataMember(Name = "CC4")]
        public int Cc4 { get; set; }

        [DataMember(Name = "DMA")]
        public int Dma { get; set; }

        [DataMember(Name = "IPR")]
        public int Ipr { get; set; }
    }
}