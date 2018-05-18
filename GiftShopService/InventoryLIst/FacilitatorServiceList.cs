using GiftShopService.Interfaces;
using System;
using System.Collections.Generic;
using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using GiftShop;
using GiftShopModel;

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
            List<FacilitatorViewModel> result = new List<FacilitatorViewModel>();
            for (int i = 0; i < source.Facilitators.Count; ++i)
            {
                result.Add(new FacilitatorViewModel
                {
                    Id = source.Facilitators[i].Id,
                    FacilitatorFIO = source.Facilitators[i].FacilitatorFIO
                });
            }
            return result;
        }

        public FacilitatorViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Facilitators.Count; ++i)
            {
                if (source.Facilitators[i].Id == id)
                {
                    return new FacilitatorViewModel
                    {
                        Id = source.Facilitators[i].Id,
                        FacilitatorFIO = source.Facilitators[i].FacilitatorFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(FacilitatorCoverModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Facilitators.Count; ++i)
            {
                if (source.Facilitators[i].Id > maxId)
                {
                    maxId = source.Facilitators[i].Id;
                }
                if (source.Facilitators[i].FacilitatorFIO == model.FacilitatorFIO)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            source.Facilitators.Add(new Facilitator
            {
                Id = maxId + 1,
                FacilitatorFIO = model.FacilitatorFIO
            });
        }

        public void UpdElement(FacilitatorCoverModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Facilitators.Count; ++i)
            {
                if (source.Facilitators[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Facilitators[i].FacilitatorFIO == model.FacilitatorFIO &&
                    source.Facilitators[i].Id != model.Id)
                {
                    throw new Exception("Уже есть сотрудник с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Facilitators[index].FacilitatorFIO = model.FacilitatorFIO;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Facilitators.Count; ++i)
            {
                if (source.Facilitators[i].Id == id)
                {
                    source.Facilitators.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
