using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
