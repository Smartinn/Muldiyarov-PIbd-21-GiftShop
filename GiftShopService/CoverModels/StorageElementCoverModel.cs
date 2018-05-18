using System.Runtime.Serialization;

namespace GiftShopService.CoverModels
{
    [DataContract]
    public class StorageElementCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StorageId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
