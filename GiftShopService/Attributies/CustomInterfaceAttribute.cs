using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftShopRestApi.Attributies
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class CustomInterfaceAttribute : Attribute
    {
        public string Description { get; private set; }

        public CustomInterfaceAttribute(string descript)
        {
            Description = string.Format("Описание интерфейса: ", descript);
        }
    }
}