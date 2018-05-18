using System.Runtime.Serialization;

namespace GiftShopService.CoverModels
{
    [DataContract]
    public class StorageCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StorageName { get; set; }
    }
}
