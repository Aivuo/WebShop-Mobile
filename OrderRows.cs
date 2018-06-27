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
        public float Price { get; set; }
        public string Date { get; set; }
        public CellPhone CellPhone { get; set; }
        public int CellPhoneId { get; set; }
        public Order Order { get; set; }
    }
}