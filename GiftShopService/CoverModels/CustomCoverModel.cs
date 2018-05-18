using System.Runtime.Serialization;

namespace GiftShopService.CoverModels
{
    [DataContract]
    public class CustomCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int GiftId { get; set; }
        [DataMember]
        public int? FacilitatorId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Summa { get; set; }
    }
}
