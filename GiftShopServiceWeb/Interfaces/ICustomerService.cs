using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerViewModel> GetList();

        CustomerViewModel GetElement(int id);

        void AddElement(CustomerCoverModel model);

        void UpdElement(CustomerCoverModel model);

        void DelElement(int id);
    }
}
