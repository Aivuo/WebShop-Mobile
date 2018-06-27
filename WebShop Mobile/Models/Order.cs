using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}