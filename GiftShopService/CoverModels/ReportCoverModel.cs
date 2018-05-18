using System;
using System.Runtime.Serialization;

namespace GiftShopService.CoverModels
{
    [DataContract]
    public class ReportCoverModel
    {
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public DateTime? DateFrom { get; set; }
        [DataMember]
        public DateTime? DateTo { get; set; }
    }
}
