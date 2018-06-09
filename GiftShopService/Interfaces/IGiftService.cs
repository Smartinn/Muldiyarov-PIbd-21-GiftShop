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
    [CustomInterface("Интерфейс для работы с услугами")]
    public interface IGiftService
    {
        [CustomMethod("Метод получения списка услуг")]
        List<GiftViewModel> GetList();

        [CustomMethod("Метод получения услуги по id")]
        GiftViewModel GetElement(int id);

        [CustomMethod("Метод добавления услуги")]
        void AddElement(GiftCoverModel model);

        [CustomMethod("Метод обновления информации об услуге")]
        void UpdElement(GiftCoverModel model);

        [CustomMethod("Метод удаления услуги")]
        void DelElement(int id);
    }
}
