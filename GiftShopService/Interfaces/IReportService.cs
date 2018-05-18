using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using System.Collections.Generic;

namespace GiftShopService.Interfaces
{
    public interface IReportService
    {
        void SaveGiftPrice(ReportCoverModel model);

        List<StorageLoadViewModel> GetStorageLoad();

        void SaveStorageLoad(ReportCoverModel model);

        List<CustomerCustomsModel> GetCustomerCustoms(ReportCoverModel model);

        void SaveCustomerCustoms(ReportCoverModel model);
    }
}
