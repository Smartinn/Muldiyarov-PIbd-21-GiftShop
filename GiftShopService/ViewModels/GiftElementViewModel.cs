using System.Runtime.Serialization;

namespace GiftShopService.ViewModels
{
    [DataContract]
    public class GiftElementViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int GiftId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string ElementName { get; set; }
    }
}
