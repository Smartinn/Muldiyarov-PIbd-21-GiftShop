﻿using GiftShopRestApi.Attributies;
using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopService.Interfaces
{
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface ICustomerService
    {
        [CustomMethod("Метод получения списка клиентов")]
        List<CustomerViewModel> GetList();

        [CustomMethod("Метод получения клиента по id")]
        CustomerViewModel GetElement(int id);

        [CustomMethod("Метод добавления клиента")]
        void AddElement(CustomerCoverModel model);

        [CustomMethod("Метод изменения данных о клиенте")]
        void UpdElement(CustomerCoverModel model);

        [CustomMethod("Метод удаления клиента")]
        void DelElement(int id);
    }
}
