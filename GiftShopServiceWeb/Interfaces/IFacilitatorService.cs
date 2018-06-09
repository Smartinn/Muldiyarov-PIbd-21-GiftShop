using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb.Interfaces
{
    public interface IFacilitatorService
    {
        List<FacilitatorViewModel> GetList();

        FacilitatorViewModel GetElement(int id);

        void AddElement(FacilitatorCoverModel model);

        void UpdElement(FacilitatorCoverModel model);

        void DelElement(int id);
    }
}
