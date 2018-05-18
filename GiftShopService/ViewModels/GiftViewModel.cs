using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GiftShopService.ViewModels
{
    [DataContract]
    public class GiftViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string GiftName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<GiftElementViewModel> GiftElements { get; set; }
    }
}
