using System.Runtime.Serialization;

namespace GiftShopService.CoverModels
{
    [DataContract]
    public class GiftElementCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int GiftId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
