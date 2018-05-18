using GiftShopModel;
using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiftShopService.InventoryDB
{
    public class StorageServiceBD : IStorageService
    {
        private GiftDBContext context;

        public StorageServiceBD(GiftDBContext context)
        {
            this.context = context;
        }

        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = context.Storages
                .Select(rec => new StorageViewModel
                {
                    Id = rec.Id,
                    StorageName = rec.StorageName,
                    StorageElements = context.StorageElements
                            .Where(recPC => recPC.StorageId == rec.Id)
                            .Select(recPC => new StorageElementViewModel
                            {
                                Id = recPC.Id,
                                StorageId = recPC.StorageId,
                                ElementId = recPC.ElementId,
                                ElementName = recPC.Element.ElementName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public StorageViewModel GetElement(int id)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StorageViewModel
                {
                    Id = element.Id,
                    StorageName = element.StorageName,
                    StorageElements = context.StorageElements
                            .Where(recPC => recPC.StorageId == element.Id)
                            .Select(recPC => new StorageElementViewModel
                            {
                                Id = recPC.Id,
                                StorageId = recPC.StorageId,
                                ElementId = recPC.ElementId,
                                ElementName = recPC.Element.ElementName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StorageCoverModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            context.Storages.Add(new Storage
            {
                StorageName = model.StorageName
            });
            context.SaveChanges();
        }

        public void UpdElement(StorageCoverModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec =>
                                        rec.StorageName == model.StorageName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StorageName = model.StorageName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.StorageElements.RemoveRange(
                                            context.StorageElements.Where(rec => rec.StorageId == id));
                        context.Storages.Remove(element);
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
