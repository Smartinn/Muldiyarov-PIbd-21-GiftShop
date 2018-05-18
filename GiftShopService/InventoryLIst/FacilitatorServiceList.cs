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
    public class FacilitatorServiceList : IFacilitatorService
    {
        private DataListSingleton source;

        public FacilitatorServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<FacilitatorViewModel> GetList()
        {
            List<FacilitatorViewModel> result = source.Facilitators
                .Select(rec => new FacilitatorViewModel
                {
                    Id = rec.Id,
                    FacilitatorFIO = rec.FacilitatorFIO
                })
                .ToList();
            return result;
        }

        public FacilitatorViewModel GetElement(int id)
        {
            Facilitator element = source.Facilitators.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new FacilitatorViewModel
                {
                    Id = element.Id,
                    FacilitatorFIO = element.FacilitatorFIO
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(FacilitatorCoverModel model)
        {
            Facilitator element = source.Facilitators.FirstOrDefault(rec => rec.FacilitatorFIO == model.FacilitatorFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            int maxId = source.Facilitators.Count > 0 ? source.Facilitators.Max(rec => rec.Id) : 0;
            source.Facilitators.Add(new Facilitator
            {
                Id = maxId + 1,
                FacilitatorFIO = model.FacilitatorFIO
            });
        }

        public void UpdElement(FacilitatorCoverModel model)
        {
            Facilitator element = source.Facilitators.FirstOrDefault(rec =>
                                        rec.FacilitatorFIO == model.FacilitatorFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            element = source.Facilitators.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.FacilitatorFIO = model.FacilitatorFIO;
        }

        public void DelElement(int id)
        {
            Facilitator element = source.Facilitators.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Facilitators.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
