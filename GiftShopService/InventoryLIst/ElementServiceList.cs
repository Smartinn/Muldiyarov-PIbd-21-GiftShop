using GiftShopService.Interfaces;
using System;
using System.Collections.Generic;
using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using GiftShop;
using GiftShopModel;
using System.Linq;

namespace GiftShopService.InventoryLIst
{
    public class ElementServiceList : IElementService
    {
        private DataListSingleton source;

        public ElementServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ElementViewModel> GetList()
        {
            List<ElementViewModel> result = source.Elements
                .Select(rec => new ElementViewModel
                {
                    Id = rec.Id,
                    ElementName = rec.ElementName
                })
                .ToList();
            return result;
        }

        public ElementViewModel GetElement(int id)
        {
            Element element = source.Elements.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ElementViewModel
                {
                    Id = element.Id,
                    ElementName = element.ElementName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(ElementCoverModel model)
        {
            Element element = source.Elements.FirstOrDefault(rec => rec.ElementName == model.ElementName);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            int maxId = source.Elements.Count > 0 ? source.Elements.Max(rec => rec.Id) : 0;
            source.Elements.Add(new Element
            {
                Id = maxId + 1,
                ElementName = model.ElementName
            });
        }

        public void UpdElement(ElementCoverModel model)
        {
            Element element = source.Elements.FirstOrDefault(rec =>
                                        rec.ElementName == model.ElementName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            element = source.Elements.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ElementName = model.ElementName;
        }

        public void DelElement(int id)
        {
            Element element = source.Elements.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Elements.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
