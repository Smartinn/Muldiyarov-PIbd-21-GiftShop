using System.Runtime.Serialization;
namespace GiftShopService.ViewModels
{
    [DataContract]
    public class StorageElementViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StorageId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string ElementName { get; set; }
    }
}
