using System.Runtime.Serialization;
namespace GiftShopService.CoverModels
{
    [DataContract]
    public class ElementCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ElementName { get; set; }

    }
}
