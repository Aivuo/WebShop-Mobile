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
        public int CustomersId { get; set; }
        public Customer CustomerId { get; set; }

    }
}