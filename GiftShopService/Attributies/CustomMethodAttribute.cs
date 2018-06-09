using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftShopRestApi.Attributies
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomMethodAttribute : Attribute
    {
        public string Description { get; private set; }

        public CustomMethodAttribute(string descript)
        {
            Description = string.Format("Описание метода: ", descript);
        }
    }
}