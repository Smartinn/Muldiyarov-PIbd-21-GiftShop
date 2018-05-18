using System;

namespace GiftShopModel
{
    public class Custom
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int GiftId { get; set; }

        public int? FacilitatorId { get; set; }

        public int Count { get; set; }

        public decimal Summa { get; set; }

        public CustomStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Gift Gift { get; set; }

        public virtual Facilitator Facilitator { get; set; }
    }
}
