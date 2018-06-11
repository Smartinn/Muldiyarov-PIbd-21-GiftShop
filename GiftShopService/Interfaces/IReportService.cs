using GiftShopRestApi.Attributies;
using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using System.Collections.Generic;

namespace GiftShopService.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IReportService
    {
        [CustomMethod("Метод сохранения прайса услуг в файл")]
        void SaveGiftPrice(ReportCoverModel model);

        [CustomMethod("Метод получения списка загруженности складов")]
        List<StorageLoadViewModel> GetStorageLoad();

        [CustomMethod("Метод сохранения списка загруженности складов в файл")]
        void SaveStorageLoad(ReportCoverModel model);

        [CustomMethod("Метод получения списка заказов клиентов")]
        List<CustomerCustomsModel> GetCustomerCustoms(ReportCoverModel model);

        [CustomMethod("Метод созранения списка заказов клиентов в файл")]
        void SaveCustomerCustoms(ReportCoverModel model);
    }
}
