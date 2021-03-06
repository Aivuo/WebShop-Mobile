﻿using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WebShopMobileDb : DbContext
    {
        public WebShopMobileDb() : base("name=WebshopMobileDb") { }
        
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CellPhone> CellPhones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }

    }
}