using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb.CoverModels
{
    public class StorageElementCoverModel
    {
        public int Id { get; set; }

        public int StorageId { get; set; }

        public int ElementId { get; set; }

        public int Count { get; set; }
    }
}
