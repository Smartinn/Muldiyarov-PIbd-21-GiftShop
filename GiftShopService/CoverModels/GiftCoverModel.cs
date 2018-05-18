using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopService.CoverModels
{
    public class GiftCoverModel
    {
        public int Id { get; set; }

        public string GiftName { get; set; }

        public decimal Price { get; set; }

        public List<GiftElementCoverModel> GiftElements { get; set; }
    }
}
