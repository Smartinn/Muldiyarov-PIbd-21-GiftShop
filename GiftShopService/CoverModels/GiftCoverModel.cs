using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GiftShopService.CoverModels
{
    [DataContract]
    public class GiftCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string GiftName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<GiftElementCoverModel> GiftElements { get; set; }
    }
}
