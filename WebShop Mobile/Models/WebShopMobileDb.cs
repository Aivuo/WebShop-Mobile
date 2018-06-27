using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class WebShopMobileDb : DbContext
    {
        
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CellPhones> CellPhones { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderRows> OrderRows { get; set; }

    }
}