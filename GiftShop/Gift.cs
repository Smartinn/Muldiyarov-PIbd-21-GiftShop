using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GiftShopModel
{
    public class Gift
    {
        public int Id { get; set; }

        [Required]
        public string GiftName { get; set; }

        [Required]
        public decimal Value { get; set; }

        [ForeignKey("GiftId")]
        public virtual List<Custom> Customs { get; set; }

        [ForeignKey("GiftId")]
        public virtual List<GiftElement> GiftElements { get; set; }
    }
}
