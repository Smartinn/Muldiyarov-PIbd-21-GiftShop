using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopService.ViewModels
{
    public class CustomViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerFIO { get; set; }

        public int GiftId { get; set; }

        public string GiftName { get; set; }

        public int? FacilitatorId { get; set; }

        public string FacilitatorName { get; set; }

        public int Count { get; set; }

        public decimal Summa { get; set; }

        public string Status { get; set; }

        public string DateCreate { get; set; }

        public string DateImplement { get; set; }
    }
}
