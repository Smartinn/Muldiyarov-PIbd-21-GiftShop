using System.Runtime.Serialization;

namespace GiftShopService.CoverModels
{
    [DataContract]
    public class FacilitatorCoverModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FacilitatorFIO { get; set; }
    }
}
