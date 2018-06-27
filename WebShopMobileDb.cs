using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class WebShopMobileDb : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CellPhone> CellPhones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRows> OrderRows { get; set; }

    }
}