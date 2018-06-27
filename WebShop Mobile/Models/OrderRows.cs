using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class OrderRows
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public float Price { get; set; }
        public string Date { get; set; }
        public string Cellphone { get; set; }
        public int CellphoneId { get; set; }
        public Cellphone Cellphone { get; set; }
    }
}