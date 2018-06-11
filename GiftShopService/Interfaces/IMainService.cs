using GiftShopRestApi.Attributies;
using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopService.Interfaces
{

    [CustomInterface("Интерфейс работы с главным окном")]
    public interface IMainService
    {
        [CustomMethod("Метод получения заказов")]
        List<CustomViewModel> GetList();

        [CustomMethod("Метод для создания заказа")]
        void CreateCustom(CustomCoverModel model);

        [CustomMethod("Метод для отправки заказа в работу")]
        void TakeCustom(CustomCoverModel model);

        [CustomMethod("Метод завершения заказа")]
        void FinishCustom(int id);

        [CustomMethod("Метод оплаты заказа")]
        void PayCustom(int id);

        [CustomMethod("Метод пополнения складов")]
        void PutElementInStorage(StorageElementCoverModel model);
    }
}
