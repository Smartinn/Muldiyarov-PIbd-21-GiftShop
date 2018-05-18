using GiftShopService.Interfaces;
using System;
using System.Collections.Generic;
using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using GiftShop;
using GiftShopModel;

namespace GiftShopService.InventoryLIst
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
            List<GiftViewModel> result = new List<GiftViewModel>();
            for (int i = 0; i < source.Gifts.Count; ++i)
            {
                List<GiftElementViewModel> GiftComponents = new List<GiftElementViewModel>();
                for (int j = 0; j < source.GiftElements.Count; ++j)
                {
                    if (source.GiftElements[j].ElementId == source.Gifts[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.GiftElements[j].ElementId == source.Elements[k].Id)
                            {
                                componentName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        GiftComponents.Add(new GiftElementViewModel
                        {
                            Id = source.GiftElements[j].Id,
                            ElementId = source.GiftElements[j].ElementId,
                            GiftId = source.GiftElements[j].GiftId,
                            ElementName = componentName,
                            Count = source.GiftElements[j].Count
                        });
                    }
                }
                result.Add(new GiftViewModel
                {
                    Id = source.Gifts[i].Id,
                    GiftName = source.Gifts[i].GiftName,
                    Price = source.Gifts[i].Value,
                    GiftElements = GiftComponents
                });
            }
            return result;
        }

        public GiftViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Gifts.Count; ++i)
            {
                List<GiftElementViewModel> giftComponents = new List<GiftElementViewModel>();
                for (int j = 0; j < source.GiftElements.Count; ++j)
                {
                    if (source.GiftElements[j].GiftId == source.Gifts[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.GiftElements[j].ElementId == source.Elements[k].Id)
                            {
                                componentName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        giftComponents.Add(new GiftElementViewModel
                        {
                            Id = source.GiftElements[j].Id,
                            GiftId = source.GiftElements[j].GiftId,
                            ElementId = source.GiftElements[j].ElementId,
                            ElementName = componentName,
                            Count = source.GiftElements[j].Count
                        });
                    }
                }
                if (source.Gifts[i].Id == id)
                {
                    return new GiftViewModel
                    {
                        Id = source.Gifts[i].Id,
                        GiftName = source.Gifts[i].GiftName,
                        Price = source.Gifts[i].Value,
                        GiftElements = giftComponents
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(GiftCoverModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Gifts.Count; ++i)
            {
                if (source.Gifts[i].Id > maxId)
                {
                    maxId = source.Gifts[i].Id;
                }
                if (source.Gifts[i].GiftName == model.GiftName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Gifts.Add(new Gift
            {
                Id = maxId + 1,
                GiftName = model.GiftName,
                Value = model.Price
            });
            int maxPCId = 0;
            for (int i = 0; i < source.GiftElements.Count; ++i)
            {
                if (source.GiftElements[i].Id > maxPCId)
                {
                    maxPCId = source.GiftElements[i].Id;
                }
            }
            for (int i = 0; i < model.GiftElements.Count; ++i)
            {
                for (int j = 1; j < model.GiftElements.Count; ++j)
                {
                    if (model.GiftElements[i].ElementId ==
                        model.GiftElements[j].ElementId)
                    {
                        model.GiftElements[i].Count +=
                            model.GiftElements[j].Count;
                        model.GiftElements.RemoveAt(j--);
                    }
                }
            }
            for (int i = 0; i < model.GiftElements.Count; ++i)
            {
                source.GiftElements.Add(new GiftElement
                {
                    Id = ++maxPCId,
                    GiftId = maxId + 1,
                    ElementId = model.GiftElements[i].ElementId,
                    Count = model.GiftElements[i].Count
                });
            }
        }

        public void UpdElement(GiftCoverModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Gifts.Count; ++i)
            {
                if (source.Gifts[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Gifts[i].GiftName == model.GiftName &&
                    source.Gifts[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Gifts[index].GiftName = model.GiftName;
            source.Gifts[index].Value = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.GiftElements.Count; ++i)
            {
                if (source.GiftElements[i].Id > maxPCId)
                {
                    maxPCId = source.GiftElements[i].Id;
                }
            }
            for (int i = 0; i < source.GiftElements.Count; ++i)
            {
                if (source.GiftElements[i].GiftId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.GiftElements.Count; ++j)
                    {
                        if (source.GiftElements[i].Id == model.GiftElements[j].Id)
                        {
                            source.GiftElements[i].Count = model.GiftElements[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        source.GiftElements.RemoveAt(i--);
                    }
                }
            }
            for (int i = 0; i < model.GiftElements.Count; ++i)
            {
                if (model.GiftElements[i].Id == 0)
                {
                    for (int j = 0; j < source.GiftElements.Count; ++j)
                    {
                        if (source.GiftElements[j].GiftId == model.Id &&
                            source.GiftElements[j].ElementId == model.GiftElements[i].ElementId)
                        {
                            source.GiftElements[j].Count += model.GiftElements[i].Count;
                            model.GiftElements[i].Id = source.GiftElements[j].Id;
                            break;
                        }
                    }
                    if (model.GiftElements[i].Id == 0)
                    {
                        source.GiftElements.Add(new GiftElement
                        {
                            Id = ++maxPCId,
                            GiftId = model.Id,
                            ElementId = model.GiftElements[i].ElementId,
                            Count = model.GiftElements[i].Count
                        });
                    }
                }
            }
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.GiftElements.Count; ++i)
            {
                if (source.GiftElements[i].GiftId == id)
                {
                    source.GiftElements.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Gifts.Count; ++i)
            {
                if (source.Gifts[i].Id == id)
                {
                    source.Gifts.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

    }
}
