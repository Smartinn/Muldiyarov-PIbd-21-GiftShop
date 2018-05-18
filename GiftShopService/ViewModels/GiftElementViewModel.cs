using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopService.ViewModels
{
    public class GiftElementViewModel
    {
        public int Id { get; set; }

        public int GiftId { get; set; }

        public int ElementId { get; set; }

        public int Count { get; set; }
        public string ElementName { get; set; }
    }
}
