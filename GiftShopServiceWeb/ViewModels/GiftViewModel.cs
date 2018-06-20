
using System.Collections.Generic;

namespace GiftShopServiceWeb.ViewModels
{
    public class GiftViewModel
    {
        public int Id { get; set; }

        public string GiftName { get; set; }

        public decimal Price { get; set; }

        public List<GiftElementViewModel> GiftElements { get; set; }
    }
}
