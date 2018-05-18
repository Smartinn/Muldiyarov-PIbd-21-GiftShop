using GiftShopService.Interfaces;
using System;
using System.Collections.Generic;
using GiftShopService.CoverModels;
using GiftShopService.ViewModels;
using GiftShop;
using GiftShopModel;

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
            List<StorageViewModel> result = new List<StorageViewModel>();
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageElementViewModel> StorageElements = new List<StorageElementViewModel>();
                for (int j = 0; j < source.StoragesElement.Count; ++j)
                {
                    if (source.StoragesElement[j].StorageId == source.Storages[i].Id)
                    {
                        string elementName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.GiftElements[j].ElementId == source.Elements[k].Id)
                            {
                                elementName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        StorageElements.Add(new StorageElementViewModel
                        {
                            Id = source.StoragesElement[j].Id,
                            StorageId = source.StoragesElement[j].StorageId,
                            ElementId = source.StoragesElement[j].ElementId,
                            ElementName = elementName,
                            Count = source.StoragesElement[j].Count
                        });
                    }
                }
                result.Add(new StorageViewModel
                {
                    Id = source.Storages[i].Id,
                    StorageName = source.Storages[i].StorageName,
                    StorageElements = StorageElements
                });
            }
            return result;
        }

        public StorageViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageElementViewModel> StorageElements = new List<StorageElementViewModel>();
                for (int j = 0; j < source.StoragesElement.Count; ++j)
                {
                    if (source.StoragesElement[j].StorageId == source.Storages[i].Id)
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
                        StorageElements.Add(new StorageElementViewModel
                        {
                            Id = source.StoragesElement[j].Id,
                            StorageId = source.StoragesElement[j].StorageId,
                            ElementId = source.StoragesElement[j].ElementId,
                            ElementName = componentName,
                            Count = source.StoragesElement[j].Count
                        });
                    }
                }
                if (source.Storages[i].Id == id)
                {
                    return new StorageViewModel
                    {
                        Id = source.Storages[i].Id,
                        StorageName = source.Storages[i].StorageName,
                        StorageElements = StorageElements
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StorageCoverModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id > maxId)
                {
                    maxId = source.Storages[i].Id;
                }
                if (source.Storages[i].StorageName == model.StorageName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }

        public void UpdElement(StorageCoverModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Storages[i].StorageName == model.StorageName &&
                    source.Storages[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Storages[index].StorageName = model.StorageName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.StoragesElement.Count; ++i)
            {
                if (source.StoragesElement[i].StorageId == id)
                {
                    source.StoragesElement.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == id)
                {
                    source.Storages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
