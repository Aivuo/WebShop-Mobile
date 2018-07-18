using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class OrderRow
    {
        [Display(Name = "Beställningsprodukt id")]
        public int Id { get; set; }
        [Display(Name = "Pris")]
        public float Price { get; set; }
        [Display(Name = "Datum")]
        public string Date { get; set; }

        [Display(Name = "Beställnings id")]
        public int OrderId { get; set; }
        [Display(Name = "Beställning")]
        public Order Order { get; set; }
        [Display(Name = "Mobiltelefon id")]
        public int CellPhoneId { get; set; }

        [Required]
        [Display(Name = "Mobiltelefon")]
        public CellPhone CellPhone { get; set; }

    }
}