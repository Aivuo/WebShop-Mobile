using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class TestDb : DbContext
    {
        public DbSet<TestPerson> TestPeople { get; set; }
    }
}