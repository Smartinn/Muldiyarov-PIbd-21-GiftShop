using System.Runtime.Serialization;
namespace GiftShopService.CoverModels
{
    [DataContract]
    public class CustomerCoverModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public string CustomerFIO { get; set; }
    }
}
