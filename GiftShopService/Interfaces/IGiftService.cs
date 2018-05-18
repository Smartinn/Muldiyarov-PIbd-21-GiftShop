using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopService.Interfaces
{
    public interface IGiftService
    {
        List<GiftViewModel> GetList();

        GiftViewModel GetElement(int id);

        void AddElement(GiftCoverModel model);

        void UpdElement(GiftCoverModel model);

        void DelElement(int id);

    }
}
