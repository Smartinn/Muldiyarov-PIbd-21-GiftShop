using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb.ViewModels
{
    public class StorageViewModel
    {
        public List<StorageElementViewModel> StorageElements;

        public int Id { get; set; }

        public string StorageName { get; set; }
    }
}
