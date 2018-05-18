﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopService.ViewModels
{
    public class CustomerCustomsModel
    {
        public string CustomerName { get; set; }

        public string DateCreate { get; set; }

        public string GiftName { get; set; }

        public int Count { get; set; }

        public decimal Summa { get; set; }

        public string Status { get; set; }
    }
}
