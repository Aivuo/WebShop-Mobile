using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Beställnings datum")]
        public string OrderDate { get; set; }

        [Display(Name = "Kund id")]
        public int CustomerId { get; set; }
        [Display(Name = "Kund")]
        public Customer Customer { get; set; }

        [Display(Name = "Beställnings produkter")]
        public List<OrderRow> OrderRows { get; set; }

        [Display(Name = "Beställt")]
        public bool Processed { get; set; }

        public Order()
        {
            OrderRows = new List<OrderRow>();
        }

    }
}