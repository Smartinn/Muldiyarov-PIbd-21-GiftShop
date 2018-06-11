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
    [CustomInterface("Интерфейс для работы с исполнителями")]
    public interface IFacilitatorService
    {
        [CustomMethod("Метод получения списка исполнителей")]
        List<FacilitatorViewModel> GetList();

        [CustomMethod("Метод получения исполнителя по id")]
        FacilitatorViewModel GetElement(int id);

        [CustomMethod("Метод добавления исполнителя")]
        void AddElement(FacilitatorCoverModel model);

        [CustomMethod("Метод обновления информации о испонители")]
        void UpdElement(FacilitatorCoverModel model);

        [CustomMethod("Метод удаления исполнителя")]
        void DelElement(int id);
    }
}
