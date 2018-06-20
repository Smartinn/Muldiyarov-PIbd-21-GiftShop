using GiftShopServiceWeb.Interfaces;
using System;
using System.Collections.Generic;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.ViewModels;
using System.Linq;
using GiftShopWeb;

namespace GiftShopServiceWeb.InventoryDB
{
    public class GiftServiceBD : IGiftService
    {
        private GiftDBContext context;

        public GiftServiceBD()
        {
            this.context = new GiftDBContext();
        }

        public GiftServiceBD(GiftDBContext context)
        {
            this.context = context;
        }

        public List<GiftViewModel> GetList()
        {
            List<GiftViewModel> result = context.Gifts
                .Select(rec => new GiftViewModel
                {
                    Id = rec.Id,
                    GiftName = rec.GiftName,
                    Price = rec.Value,
                    GiftElements = context.GiftElements
                            .Where(recPC => recPC.GiftId == rec.Id)
                            .Select(recPC => new GiftElementViewModel
                            {
                                Id = recPC.Id,
                                GiftId = recPC.GiftId,
                                ElementId = recPC.ElementId,
                                ElementName = recPC.Element.ElementName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public GiftViewModel GetElement(int id)
        {
            Gift element = context.Gifts.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new GiftViewModel
                {
                    Id = element.Id,
                    GiftName = element.GiftName,
                    Price = element.Value,
                    GiftElements = context.GiftElements
                            .Where(recPC => recPC.GiftId == element.Id)
                            .Select(recPC => new GiftElementViewModel
                            {
                                Id = recPC.Id,
                                GiftId = recPC.GiftId,
                                ElementId = recPC.ElementId,
                                ElementName = recPC.Element.ElementName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(GiftCoverModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Gift element = context.Gifts.FirstOrDefault(rec => rec.GiftName == model.GiftName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Gift
                    {
                        GiftName = model.GiftName,
                        Value = model.Price
                    };
                    context.Gifts.Add(element);
                    context.SaveChanges();
                    var groupComponents = model.GiftElements
                                                .GroupBy(rec => rec.ElementId)
                                                .Select(rec => new
                                                {
                                                    ComponentId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupComponent in groupComponents)
                    {
                        context.GiftElements.Add(new GiftElement
                        {
                            GiftId = element.Id,
                            ElementId = groupComponent.ComponentId,
                            Count = groupComponent.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(GiftCoverModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Gift element = context.Gifts.FirstOrDefault(rec =>
                                        rec.GiftName == model.GiftName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Gifts.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.GiftName = model.GiftName;
                    element.Value = model.Price;
                    context.SaveChanges();
                    var compIds = model.GiftElements.Select(rec => rec.ElementId).Distinct();
                    var updateComponents = context.GiftElements
                                                    .Where(rec => rec.GiftId == model.Id &&
                                                        compIds.Contains(rec.GiftId));
                    foreach (var updateComponent in updateComponents)
                    {
                        updateComponent.Count = model.GiftElements
                                                        .FirstOrDefault(rec => rec.Id == updateComponent.Id).Count;
                    }
                    context.SaveChanges();
                    context.GiftElements.RemoveRange(
                                        context.GiftElements.Where(rec => rec.GiftId == model.Id &&
                                                                            !compIds.Contains(rec.ElementId)));
                    context.SaveChanges();
                    var groupComponents = model.GiftElements
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.ElementId)
                                                .Select(rec => new
                                                {
                                                    ComponentId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupComponent in groupComponents)
                    {
                        GiftElement elementPC = context.GiftElements
                                                .FirstOrDefault(rec => rec.GiftId == model.Id &&
                                                                rec.ElementId == groupComponent.ComponentId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupComponent.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.GiftElements.Add(new GiftElement
                            {
                                GiftId = model.Id,
                                ElementId = groupComponent.ComponentId,
                                Count = groupComponent.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Gift element = context.Gifts.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.GiftElements.RemoveRange(
                                            context.GiftElements.Where(rec => rec.GiftId == id));
                        context.Gifts.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
