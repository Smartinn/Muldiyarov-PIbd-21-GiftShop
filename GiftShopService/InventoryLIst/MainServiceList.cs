using GiftShopService.Interfaces;
using System;
using System.Collections.Generic;
using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using GiftShop;
using GiftShopModel;

namespace GiftShopService.InventoryLIst
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<CustomViewModel> GetList()
        {
            List<CustomViewModel> result = new List<CustomViewModel>();
            for (int i = 0; i < source.Customs.Count; ++i)
            {
                string clientFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if (source.Customers[j].Id == source.Customs[i].CustomerId)
                    {
                        clientFIO = source.Customers[j].CustomerFIO;
                        break;
                    }
                }
                string productName = string.Empty;
                for (int j = 0; j < source.Gifts.Count; ++j)
                {
                    if (source.Gifts[j].Id == source.Customs[i].GiftId)
                    {
                        productName = source.Gifts[j].GiftName;
                        break;
                    }
                }
                string implementerFIO = string.Empty;
                if (source.Customs[i].FacilitatorId.HasValue)
                {
                    for (int j = 0; j < source.Facilitators.Count; ++j)
                    {
                        if (source.Facilitators[j].Id == source.Customs[i].FacilitatorId.Value)
                        {
                            implementerFIO = source.Facilitators[j].FacilitatorFIO;
                            break;
                        }
                    }
                }
                result.Add(new CustomViewModel
                {
                    Id = source.Customs[i].Id,
                    CustomerId = source.Customs[i].CustomerId,
                    CustomerFIO = clientFIO,
                    GiftId = source.Customs[i].GiftId,
                    GiftName = productName,
                    FacilitatorId = source.Customs[i].FacilitatorId,
                    FacilitatorName = implementerFIO,
                    Count = source.Customs[i].Count,
                    Summa = source.Customs[i].Summa,
                    DateCreate = source.Customs[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Customs[i].DateImplement?.ToLongDateString(),
                    Status = source.Customs[i].Status.ToString()
                });
            }
            return result;
        }

        public void CreateCustom(CustomCoverModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Customs.Count; ++i)
            {
                if (source.Customs[i].Id > maxId)
                {
                    maxId = source.Customers[i].Id;
                }
            }
            source.Customs.Add(new Custom
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                GiftId = model.GiftId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Summa = model.Summa,
                Status = CustomStatus.Принят
            });
        }

        public void TakeCustom(CustomCoverModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Customs.Count; ++i)
            {
                if (source.Customs[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            for (int i = 0; i < source.GiftElements.Count; ++i)
            {
                if (source.GiftElements[i].GiftId == source.Customs[index].GiftId)
                {
                    int countOnStocks = 0;
                    for (int j = 0; j < source.StoragesElement.Count; ++j)
                    {
                        if (source.StoragesElement[j].ElementId == source.GiftElements[i].ElementId)
                        {
                            countOnStocks += source.StoragesElement[j].Count;
                        }
                    }
                    if (countOnStocks < source.GiftElements[i].Count)
                    {
                        for (int j = 0; j < source.Elements.Count; ++j)
                        {
                            if (source.Elements[j].Id == source.GiftElements[i].GiftId)
                            {
                                throw new Exception("Не достаточно компонента " + source.Elements[j].ElementName +
                                    " требуется " + source.GiftElements[i].Count + ", в наличии " + countOnStocks);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < source.GiftElements.Count; ++i)
            {
                if (source.GiftElements[i].GiftId == source.Customs[index].GiftId)
                {
                    int countOnStocks = source.GiftElements[i].Count * source.Customs[index].Count;
                    for (int j = 0; j < source.StoragesElement.Count; ++j)
                    {
                        if (source.StoragesElement[j].ElementId == source.GiftElements[i].ElementId)
                        {
                            if (source.StoragesElement[j].Count >= countOnStocks)
                            {
                                source.StoragesElement[j].Count -= countOnStocks;
                                break;
                            }
                            else
                            {
                                countOnStocks -= source.StoragesElement[j].Count;
                                source.StoragesElement[j].Count = 0;
                            }
                        }
                    }
                }
            }
            source.Customs[index].FacilitatorId = model.FacilitatorId;
            source.Customs[index].DateImplement = DateTime.Now;
            source.Customs[index].Status = CustomStatus.Выполняется;
        }

        public void FinishCustom(int id)
        {
            int index = -1;
            for (int i = 0; i < source.Customs.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Customs[index].Status = CustomStatus.Готов;
        }

        public void PayCustom(int id)
        {
            int index = -1;
            for (int i = 0; i < source.Customs.Count; ++i)
            {
                if (source.Customers[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Customs[index].Status = CustomStatus.Оплачен;
        }

        public void PutElementInStorage(StorageElementCoverModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.StoragesElement.Count; ++i)
            {
                if (source.StoragesElement[i].StorageId == model.StorageId &&
                    source.StoragesElement[i].ElementId == model.ElementId)
                {
                    source.StoragesElement[i].Count += model.Count;
                    return;
                }
                if (source.StoragesElement[i].Id > maxId)
                {
                    maxId = source.StoragesElement[i].Id;
                }
            }
            source.StoragesElement.Add(new StorageElement
            {
                Id = ++maxId,
                StorageId = model.StorageId,
                ElementId = model.ElementId,
                Count = model.Count
            });
        }
    }
}
