using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class RecieptViewModel
    {
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

        public string OrderDate { get; set; }
        public List<OrderRow> OrderRows { get; set; }

        public string PaymentOption { get; set; }

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