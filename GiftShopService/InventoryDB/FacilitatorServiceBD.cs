using GiftShopModel;
using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiftShopService.InventoryDB
{
    public class FacilitatorServiceBD : IFacilitatorService
    {
        private GiftDBContext context;

        public FacilitatorServiceBD(GiftDBContext context)
        {
            this.context = context;
        }

        public List<FacilitatorViewModel> GetList()
        {
            List<FacilitatorViewModel> result = context.Facilitators
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
            Facilitator element = context.Facilitators.FirstOrDefault(rec => rec.Id == id);
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
            Facilitator element = context.Facilitators.FirstOrDefault(rec => rec.FacilitatorFIO == model.FacilitatorFIO);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            context.Facilitators.Add(new Facilitator
            {
                FacilitatorFIO = model.FacilitatorFIO
            });
            context.SaveChanges();
        }

        public void UpdElement(FacilitatorCoverModel model)
        {
            Facilitator element = context.Facilitators.FirstOrDefault(rec =>
                                        rec.FacilitatorFIO == model.FacilitatorFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть сотрудник с таким ФИО");
            }
            element = context.Facilitators.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.FacilitatorFIO = model.FacilitatorFIO;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Facilitator element = context.Facilitators.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Facilitators.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
