using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class TestProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name ="Release year")]
        public string ReleaseYear { get; set; }
        public float Price { get; set; }
        public List<Color> Colors { get; set; }
        public string Manufacturer { get; set; }

        [Display(Name ="Screen resolution")]
        public string ScreenResolution { get; set; }
        public int Stock { get; set; }
        public bool Retina { get; set; }

        [Display(Name ="Camera resolution(megapixel)")]
        public string CameraMP { get; set; }
        public bool Frontpage { get; set; }

        [Display(Name ="Product code")]
        public string ProductCode { get; set; }
        public bool Discontinued { get; set; }

        public TestProduct()
        {
            Colors = new List<Color>();
        }

        public enum Color
        {
            Red,
            Blue,
            Green,
            Yellow,
            Purple,
            Pink,
            Silver,
            Gold,
            Obsidian
        }
    }
}