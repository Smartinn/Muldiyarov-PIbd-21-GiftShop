﻿using GiftShopWeb;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GiftShopServiceWeb
{
    [Table("Gift_Db")]
    public class GiftDBContext : DbContext
    {
        public GiftDBContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Element> Elements { get; set; }

        public virtual DbSet<Facilitator> Facilitators { get; set; }

        public virtual DbSet<Custom> Customs { get; set; }

        public virtual DbSet<Gift> Gifts { get; set; }

        public virtual DbSet<GiftElement> GiftElements { get; set; }

        public virtual DbSet<Storage> Storages { get; set; }

        public virtual DbSet<StorageElement> StorageElements { get; set; }
    }
}
