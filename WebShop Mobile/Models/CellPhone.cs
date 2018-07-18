using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class CellPhone
    {
        [Display(Name = "Telefon id")]
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }
        [Display(Name = "Utgivningsår")]
        public string ReleaseYear { get; set; }
        [Display(Name = "Pris")]
        public float Price { get; set; }
        [Display(Name = "Färger")]
        public List<Color> Colors { get; set; }
        [Display(Name = "Retina")]
        public Boolean Retina { get; set; }
        [Display(Name = "Lagersaldo")]
        public int WarehouseStock { get; set; }
        [Display(Name = "Nyhet")]
        public Boolean News { get; set; }
        [Display(Name = "Produktkod")]
        public string ProductCode { get; set; }
        [Display(Name = "Megapixlar")]
        public string CameraPixels { get; set; }
        [Display(Name = "Tillverkare")]
        public string Developer { get; set; }
        [Display(Name = "Utgått")]
        public Boolean Discontinued { get; set; }

        public CellPhone()
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