using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string BillingAdress { get; set; }
        public string BillingZip { get; set; }
        public string BillingCity { get; set; }
        public string DeliveryAdress { get; set; }
        public string DeliveryZip { get; set; }
        public string DeliveryCity { get; set; }
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}