using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftShopWeb
{
    public class Element
    {
        public int Id { get; set; }

        [Required]
        public string ElementName { get; set; }

        [ForeignKey("ElementId")]
        public virtual List<GiftElement> GiftElements { get; set; }

        [ForeignKey("ElementId")]
        public virtual List<StorageElement> StorageElements { get; set; }
    }
}
