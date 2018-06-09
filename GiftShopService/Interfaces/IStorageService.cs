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
    [CustomInterface("Интерфейс для работы со складами")]
    public interface IStorageService
    {
        [CustomMethod("Метод получения списка складов")]
        List<StorageViewModel> GetList();

        [CustomMethod("Метод получения склада по id")]
        StorageViewModel GetElement(int id);

        [CustomMethod("Метод добавления склада")]
        void AddElement(StorageCoverModel model);

        [CustomMethod("Метод обновления информации о складе")]
        void UpdElement(StorageCoverModel model);

        [CustomMethod("Метод удаления склада")]
        void DelElement(int id);
    }
}
