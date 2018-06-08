
using GiftShopWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopServiceWeb
{
    class DataListSingleton
    {
        public static DataListSingleton instance;

        public List<Customer> Customers { get; set; }
        
        public List<Element> Elements { get; set; }
        
        public List<Facilitator> Facilitators { get; set; }
        
        public List<Custom> Customs { get; set; }
        
        public List<Gift> Gifts { get; set; }
        
        public List<GiftElement> GiftElements { get; set; }
        
        public List<Storage> Storages { get; set; }
        
        public List<StorageElement> StoragesElement { get; set; }
        
        public DataListSingleton()
        {
            Customers = new List<Customer>();
            Elements = new List<Element>();
            Facilitators = new List<Facilitator>();
            Customs = new List<Custom>();
            Gifts = new List<Gift>();
            GiftElements = new List<GiftElement>();
            Storages = new List<Storage>();
            StoragesElement = new List<StorageElement>();
        }    

        public static DataListSingleton GetInstance()
        {
            if(instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
