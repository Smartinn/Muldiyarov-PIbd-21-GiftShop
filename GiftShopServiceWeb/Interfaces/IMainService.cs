using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb.Interfaces
{
    public interface IMainService
    {
        List<CustomViewModel> GetList();

        void CreateCustom(CustomCoverModel model);

        void TakeCustom(CustomCoverModel model);

        void FinishCustom(int id);

        void PayCustom(int id);

        void PutElementInStorage(StorageElementCoverModel model);
    }
}
