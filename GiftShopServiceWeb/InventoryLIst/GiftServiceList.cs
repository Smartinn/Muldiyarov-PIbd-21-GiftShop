using GiftShopServiceWeb.Interfaces;
using System;
using System.Collections.Generic;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.ViewModels;
using System.Linq;
using GiftShopWeb;

namespace GiftShopServiceWeb.InventoryLIst
{
    public class GiftServiceList : IGiftService
    {
        private DataListSingleton source;

        public GiftServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<GiftViewModel> GetList()
        {
            List<GiftViewModel> result = source.Gifts
                .Select(rec => new GiftViewModel
                {
                    Id = rec.Id,
                    GiftName = rec.GiftName,
                    Price = rec.Value,
                    GiftElements = source.GiftElements
                            .Where(recPC => recPC.GiftId == rec.Id)
                            .Select(recPC => new GiftElementViewModel
                            {
                                Id = recPC.Id,
                                GiftId = recPC.GiftId,
                                ElementId = recPC.ElementId,
                                ElementName = source.Elements
                                    .FirstOrDefault(recC => recC.Id == recPC.ElementId)?.ElementName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public GiftViewModel GetElement(int id)
        {
            Gift element = source.Gifts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new GiftViewModel
                {
                    Id = element.Id,
                    GiftName = element.GiftName,
                    Price = element.Value,
                    GiftElements = source.GiftElements
                            .Where(recPC => recPC.GiftId == element.Id)
                            .Select(recPC => new GiftElementViewModel
                            {
                                Id = recPC.Id,
                                GiftId = recPC.GiftId,
                                ElementId = recPC.ElementId,
                                ElementName = source.Elements
                                        .FirstOrDefault(recC => recC.Id == recPC.ElementId)?.ElementName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");

            
        }

        public void AddElement(GiftCoverModel model)
        {
            Gift element = source.Gifts.FirstOrDefault(rec => rec.GiftName == model.GiftName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Gifts.Count > 0 ? source.Gifts.Max(rec => rec.Id) : 0;
            source.Gifts.Add(new Gift
            {
                Id = maxId + 1,
                GiftName = model.GiftName,
                Value = model.Price
            });
            int maxPCId = source.GiftElements.Count > 0 ?
                                    source.GiftElements.Max(rec => rec.Id) : 0;
            var groupElements = model.GiftElements
                                        .GroupBy(rec => rec.ElementId)
                                        .Select(rec => new
                                        {
                                            ElementId = rec.Key,
                                            Count = rec.Sum(r => r.Count)
                                        });
            foreach (var groupElement in groupElements)
            {
                source.GiftElements.Add(new GiftElement 
                {
                    Id = ++maxPCId,
                    GiftId = maxId + 1,
                    ElementId = groupElement.ElementId,
                    Count = groupElement.Count
                });
            }
        }

        public void UpdElement(GiftCoverModel model)
        {
            Gift element = source.Gifts.FirstOrDefault(rec =>
                                        rec.GiftName == model.GiftName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.Gifts.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.GiftName = model.GiftName;
            element.Value = model.Price;

            int maxPCId = source.GiftElements.Count > 0 ? source.GiftElements.Max(rec => rec.Id) : 0;
            var compIds = model.GiftElements.Select(rec => rec.ElementId).Distinct();
            var updateElements = source.GiftElements
                                            .Where(rec => rec.GiftId == model.Id &&
                                           compIds.Contains(rec.ElementId));
            foreach (var updateElement in updateElements)
            {
                updateElement.Count = model.GiftElements
                                                .FirstOrDefault(rec => rec.Id == updateElement.Id).Count;
            }
            source.GiftElements.RemoveAll(rec => rec.GiftId == model.Id &&
                                       !compIds.Contains(rec.ElementId));
            var groupElements = model.GiftElements
                                        .Where(rec => rec.Id == 0)
                                        .GroupBy(rec => rec.ElementId)
                                        .Select(rec => new
                                        {
                                            ElementId = rec.Key,
                                            Count = rec.Sum(r => r.Count)
                                        });
            foreach (var groupElement in groupElements)
            {
                GiftElement elementPC = source.GiftElements
                                        .FirstOrDefault(rec => rec.GiftId == model.Id &&
                                                        rec.ElementId == groupElement.ElementId);
                if (elementPC != null)
                {
                    elementPC.Count += groupElement.Count;
                }
                else
                {
                    source.GiftElements.Add(new GiftElement
                    {
                        Id = ++maxPCId,
                        GiftId = model.Id,
                        ElementId = groupElement.ElementId,
                        Count = groupElement.Count
                    });
                }
            }
            
        }

        public void DelElement(int id)
        {
            Gift element = source.Gifts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.GiftElements.RemoveAll(rec => rec.GiftId == id);
                source.Gifts.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

    }
}
