using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class Customer
    {
        [Display(Name = "Kund id")]
        public int Id { get; set; }
        [Display(Name = "Förnamn")]
        public string Firstname { get; set; }
        [Display(Name = "Efternamn")]
        public string Lastname { get; set; }

        [Display(Name = "Faktureringsadress")]
        public string BillingAdress { get; set; }
        [Display(Name = "Fakturerings postnummer")]
        public string BillingZip { get; set; }
        [Display(Name = "Fakturerings postort")]
        public string BillingCity { get; set; }

        [Display(Name = "Leveransadress")]
        public string DeliveryAdress { get; set; }
        [Display(Name = "Postnummer")]
        public string DeliveryZip { get; set; }
        [Display(Name = "Postort")]
        public string DeliveryCity { get; set; }

        [Display(Name = "Email adress")]
        public string EmailAdress { get; set; }
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Display(Name = "Beställningar")]
        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}