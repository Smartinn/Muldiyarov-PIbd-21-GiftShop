using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GiftShopService.ViewModels
{
    [DataContract]
    public class StorageViewModel
    {
        [DataMember]
        public List<StorageElementViewModel> StorageElements;
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StorageName { get; set; }
    }
}
