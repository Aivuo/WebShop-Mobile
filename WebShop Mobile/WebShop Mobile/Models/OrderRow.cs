using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class OrderRow
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Date { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int CellPhoneId { get; set; }

        [Required]
        public CellPhone CellPhone { get; set; }

    }
}