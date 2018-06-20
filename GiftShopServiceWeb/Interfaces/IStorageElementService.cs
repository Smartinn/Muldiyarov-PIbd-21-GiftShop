using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb.Interfaces
{
    public interface IStorageElementService
    {
        List<StorageViewModel> GetList();

        StorageViewModel GetElement(int id);

        void AddElement(StorageCoverModel model);

        void UpdElement(StorageCoverModel model);

        void DelElement(int id);
    }
}
