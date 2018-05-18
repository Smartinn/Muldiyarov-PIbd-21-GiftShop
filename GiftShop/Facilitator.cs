using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftShopModel
{
    public class Facilitator
    {
        public int Id { get; set; }

        [Required]
        public string FacilitatorFIO { get; set; }

        [ForeignKey("FacilitatorId")]
        public virtual List<Custom> Customs { get; set; }
    }
}
