using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class RecieptViewModel
    {
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

        [Display(Name = "Emailadress")]
        public string EmailAdress { get; set; }
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Beställnings datum")]
        public string OrderDate { get; set; }
        [Display(Name = "Produkter")]
        public List<OrderRow> OrderRows { get; set; }

        [Display(Name = "Betalningsalternativ")]
        public string PaymentOption { get; set; }

        [Display(Name = "Totalsumma")]
        public float Total { get; set; }

        public RecieptViewModel()
        {
            OrderRows = new List<OrderRow>();
        }

        public RecieptViewModel(Order order, Customer customer, string payment, float total)
        {
            Firstname = customer.Firstname;
            Lastname = customer.Lastname;

            BillingAdress = customer.BillingAdress;
            BillingCity = customer.BillingCity;
            BillingZip = customer.BillingZip;

            DeliveryAdress = customer.DeliveryAdress;
            DeliveryCity = customer.DeliveryCity;
            DeliveryZip = customer.DeliveryZip;

            EmailAdress = customer.EmailAdress;
            PhoneNumber = customer.PhoneNumber;

            OrderDate = order.OrderDate;
            OrderRows = new List<OrderRow>();

            foreach (var item in order.OrderRows)
            {
                OrderRows.Add(item);
            }

            PaymentOption = payment;

            Total = total;
        }
    }
}