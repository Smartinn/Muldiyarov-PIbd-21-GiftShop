using GiftShopModel;
using GiftShopService;
using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using GiftShopService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiftShopService.InventoryDB
{
    public class CustomerServiceBD : ICustomerService
    {
        private GiftDBContext context;

        public CustomerServiceBD(GiftDBContext context)
        {
            this.context = context;
        }

        public List<CustomerViewModel> GetList()
        {
            List<CustomerViewModel> result = context.Customers
                .Select(rec => new CustomerViewModel
                {
                    Id = rec.Id,
                    Mail = rec.Mail,
                    CustomerFIO = rec.CustomerFIO                   
                })
                .ToList();
            return result;
        }

        public CustomerViewModel GetElement(int id)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CustomerViewModel
                {
                    Id = element.Id,
                    Mail = element.Mail,
                    CustomerFIO = element.CustomerFIO,              
                    Messages = context.MessageInfos
                            .Where(recM => recM.CustomerId == element.Id)
                            .Select(recM => new MessageInfoViewModel
                            {
                        MessageId = recM.MessageId,
                        DateDelivery = recM.DateDelivery,
                        Subject = recM.Subject,
                        Body = recM.Body
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CustomerCoverModel model)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.CustomerFIO == model.CustomerFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Customers.Add(new Customer
            {
                CustomerFIO = model.CustomerFIO,
                Mail = model.Mail         
            });
            context.SaveChanges();
        }

        public void UpdElement(CustomerCoverModel model)
        {
            Customer element = context.Customers.FirstOrDefault(rec =>
                                    rec.CustomerFIO == model.CustomerFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Customers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Mail = model.Mail;
            element.CustomerFIO = model.CustomerFIO;          
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Customers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
