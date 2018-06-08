using GiftShopServiceWeb.Interfaces;
using System;
using System.Collections.Generic;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.ViewModels;
using System.Linq;
using GiftShopWeb;

namespace GiftShopServiceWeb.InventoryLIst
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
            List<CustomViewModel> result = source.Customs
                .Select(rec => new CustomViewModel
                {
                    Id = rec.Id,
                    CustomerId = rec.CustomerId,
                    GiftId = rec.GiftId,
                    FacilitatorId = rec.FacilitatorId,
                    DateCreate = rec.DateCreate.ToLongDateString(),
                    DateImplement = rec.DateImplement?.ToLongDateString(),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Summa = rec.Summa,
                    CustomerFIO = source.Customers
                                    .FirstOrDefault(recC => recC.Id == rec.CustomerId)?.CustomerFIO,
                    GiftName = source.Gifts
                                    .FirstOrDefault(recP => recP.Id == rec.GiftId)?.GiftName,
                    FacilitatorFIO = source.Facilitators
                                    .FirstOrDefault(recI => recI.Id == rec.FacilitatorId)?.FacilitatorFIO
                })
                .ToList();
            return result;
        }

        public void CreateCustom(CustomCoverModel model)
        {
            int maxId = source.Customs.Count > 0 ? source.Customs.Max(rec => rec.Id) : 0;
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
            Custom element = source.Customs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            var giftElements = source.GiftElements.Where(rec => rec.GiftId == element.GiftId);
            foreach (var giftElement in giftElements)
            {
                int countOnStorages = source.StoragesElement
                                            .Where(rec => rec.ElementId == giftElement.ElementId)
                                            .Sum(rec => rec.Count);
                if (countOnStorages < giftElement.Count*element.Count)
                {
                    var componentName = source.Elements
                                    .FirstOrDefault(rec => rec.Id == giftElement.ElementId);
                    throw new Exception("Не достаточно компонента " + componentName?.ElementName +
                        " требуется " + giftElement.Count * element.Count + ", в наличии " + countOnStorages);
                }
            }
            foreach (var giftElement in giftElements)
            {
                int countOnStorages = giftElement.Count * element.Count;
                var storagesElement = source.StoragesElement
                                            .Where(rec => rec.ElementId == giftElement.ElementId);
                foreach (var storageElement in storagesElement)
                {
                    if (storageElement.Count >= countOnStorages)
                    {
                        storageElement.Count -= countOnStorages;
                        break;
                    }
                    else
                    {
                        countOnStorages -= storageElement.Count;
                        storageElement.Count = 0;
                    }
                }
            }
            element.FacilitatorId = model.FacilitatorId;
            element.DateImplement = DateTime.Now;
            element.Status = CustomStatus.Выполняется;
            
        }

        public void FinishCustom(int id)
        {
            Custom element = source.Customs.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = CustomStatus.Готов;
        }

        public void PayCustom(int id)
        {
            Custom element = source.Customs.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = CustomStatus.Оплачен;
        }

        public void PutElementInStorage(StorageElementCoverModel model)
        {
            StorageElement element = source.StoragesElement
                                                .FirstOrDefault(rec => rec.StorageId == model.StorageId &&
                                                                    rec.ElementId == model.ElementId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StoragesElement.Count > 0 ? source.StoragesElement.Max(rec => rec.Id) : 0;
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
}
