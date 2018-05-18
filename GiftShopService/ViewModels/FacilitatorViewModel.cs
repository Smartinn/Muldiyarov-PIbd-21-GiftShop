using System.Runtime.Serialization;

namespace GiftShopService.ViewModels
{
    [DataContract]
    public class FacilitatorViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FacilitatorFIO { get; set; }
    }
}
