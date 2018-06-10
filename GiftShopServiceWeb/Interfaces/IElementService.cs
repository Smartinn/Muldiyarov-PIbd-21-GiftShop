using GiftShopServiceWeb.ViewModels;
using GiftShopServiceWeb.CoverModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb.Interfaces
{
   public interface IElementService
    {
        List<ElementViewModel> GetList();

        ElementViewModel GetElement(int id);

        void AddElement(ElementCoverModel model);

        void UpdElement(ElementCoverModel model);

        void DelElement(int id);

    }
}
