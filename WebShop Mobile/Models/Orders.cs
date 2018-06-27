using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        //public int CustomersId { get; set; }

        public Customers CustomerId { get; set; }

    }
}