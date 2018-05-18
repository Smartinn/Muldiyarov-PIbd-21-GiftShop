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
    public class StorageServiceList : IStorageService
    {
        private DataListSingleton source;

        public StorageServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = source.Storages
                .Select(rec => new StorageViewModel
                {
                    Id = rec.Id,
                    StorageName = rec.StorageName,
                    StorageElements = source.StoragesElement
                            .Where(recPC => recPC.StorageId == rec.Id)
                            .Select(recPC => new StorageElementViewModel
                            {
                                Id = recPC.Id,
                                StorageId = recPC.StorageId,
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

        public StorageViewModel GetElement(int id)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StorageViewModel
                {
                    Id = element.Id,
                    StorageName = element.StorageName,
                    StorageElements = source.StoragesElement
                            .Where(recPC => recPC.StorageId == element.Id)
                            .Select(recPC => new StorageElementViewModel
                            {
                                Id = recPC.Id,
                                StorageId = recPC.StorageId,
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

        public void AddElement(StorageCoverModel model)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.Id) : 0;
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }

        public void UpdElement(StorageCoverModel model)
        {
            Storage element = source.Storages.FirstOrDefault(rec =>
                                        rec.StorageName == model.StorageName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = source.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StorageName = model.StorageName;
        }

        public void DelElement(int id)
        {
            Storage element = source.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.StoragesElement.RemoveAll(rec => rec.StorageId == id);
                source.Storages.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
