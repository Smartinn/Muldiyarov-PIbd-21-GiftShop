using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb.Interfaces
{
    public interface IGiftElementService
    {
        List<GiftElementViewModel> GetList();

        GiftElementViewModel GetElement(int id);

        void AddElement(GiftElementCoverModel model);

        void UpdElement(GiftElementCoverModel model);

        void DelElement(int id);
    }
}
