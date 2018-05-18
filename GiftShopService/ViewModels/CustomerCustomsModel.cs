using System.Runtime.Serialization;


namespace GiftShopService.ViewModels
{
    [DataContract]
    public class CustomerCustomsModel
    {
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string GiftName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Summa { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
