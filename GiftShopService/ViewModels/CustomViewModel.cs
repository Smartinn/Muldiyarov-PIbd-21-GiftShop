using System.Runtime.Serialization;

namespace GiftShopService.ViewModels
{
    [DataContract]
    public class CustomViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
        [DataMember]
        public int GiftId { get; set; }
        [DataMember]
        public string GiftName { get; set; }
        [DataMember]
        public int? FacilitatorId { get; set; }
        [DataMember]
        public string FacilitatorName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Summa { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string DateImplement { get; set; }
    }
}
