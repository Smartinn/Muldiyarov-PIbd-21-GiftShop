using System.Runtime.Serialization;

namespace GiftShopService.ViewModels
{
    [DataContract]
    public class ElementViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ElementName { get; set; }

    }
}
