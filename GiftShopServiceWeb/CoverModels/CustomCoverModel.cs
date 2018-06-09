using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb.CoverModels
{
    public class CustomCoverModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int GiftId { get; set; }

        public int? FacilitatorId { get; set; }

        public int Count { get; set; }

        public decimal Summa { get; set; }
    }
}
