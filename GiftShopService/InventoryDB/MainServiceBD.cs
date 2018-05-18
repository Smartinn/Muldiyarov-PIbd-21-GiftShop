using GiftShopModel;
using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Data.Entity;

namespace GiftShopService.InventoryDB
{
    public class MainServiceBD : IMainService
    {
        private GiftDBContext context;

        public MainServiceBD(GiftDBContext context)
        {
            this.context = context;
        }

        public List<CustomViewModel> GetList()
        {
            List<CustomViewModel> result = context.Customs
                .Select(rec => new CustomViewModel
                {
                    Id = rec.Id,
                    CustomerId = rec.CustomerId,
                    GiftId = rec.GiftId,
                    FacilitatorId = rec.FacilitatorId,
                    DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                                SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                                SqlFunctions.DateName("yyyy", rec.DateCreate),
                    DateImplement = rec.DateImplement == null ? "" :
                                        SqlFunctions.DateName("dd", rec.DateImplement.Value) + " " +
                                        SqlFunctions.DateName("mm", rec.DateImplement.Value) + " " +
                                        SqlFunctions.DateName("yyyy", rec.DateImplement.Value),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Summa = rec.Summa,
                    CustomerFIO = rec.Customer.CustomerFIO,
                    GiftName = rec.Gift.GiftName,
                    FacilitatorName = rec.Facilitator.FacilitatorFIO
                })
                .ToList();
            return result;
        }

        public void CreateCustom(CustomCoverModel model)
        {
            context.Customs.Add(new Custom
            {
                CustomerId = model.CustomerId,
                GiftId = model.GiftId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Summa = model.Summa,
                Status = CustomStatus.Принят
            });
            context.SaveChanges();
        }

        public void TakeCustom(CustomCoverModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Custom element = context.Customs.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    var giftComponents = context.GiftElements
                                                .Include(rec => rec.Element)
                                                .Where(rec => rec.GiftId == element.GiftId);
                    
                    foreach (var giftComponent in giftComponents)
                    {
                        int countOnStocks = giftComponent.Count * element.Count;
                        var storageComponents = context.StorageElements
                                                    .Where(rec => rec.ElementId == giftComponent.ElementId);
                        foreach (var storageComponent in storageComponents)
                        {
                            if (storageComponent.Count >= countOnStocks)
                            {
                                storageComponent.Count -= countOnStocks;
                                countOnStocks = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStocks -= storageComponent.Count;
                                storageComponent.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStocks > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                                giftComponent.Element.ElementName + " требуется " +
                                giftComponent.Count + ", не хватает " + countOnStocks);
                        }
                    }
                    element.FacilitatorId = model.FacilitatorId;
                    element.DateImplement = DateTime.Now;
                    element.Status = CustomStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void FinishCustom(int id)
        {
            Custom element = context.Customs.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = CustomStatus.Готов;
            context.SaveChanges();
        }

        public void PayCustom(int id)
        {
            Custom element = context.Customs.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = CustomStatus.Оплачен;
            context.SaveChanges();
        }

        public void PutElementInStorage(StorageElementCoverModel model)
        {
            StorageElement element = context.StorageElements
                                                .FirstOrDefault(rec => rec.StorageId == model.StorageId &&
                                                                    rec.ElementId == model.ElementId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StorageElements.Add(new StorageElement
                {
                    StorageId = model.StorageId,
                    ElementId = model.ElementId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
