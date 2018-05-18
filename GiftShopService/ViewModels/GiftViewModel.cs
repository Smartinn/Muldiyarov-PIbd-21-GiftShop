using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopService.ViewModels
{
    public class GiftViewModel
    {
        public int Id { get; set; }

        public string GiftName { get; set; }

        public decimal Price { get; set; }

        public List<GiftElementViewModel> GiftElements { get; set; }
    }
}
