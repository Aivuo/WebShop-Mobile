using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Mobile.Models
{
    public class CellPhone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public float Price { get; set; }
        public List<Color> Colors { get; set; }
        public Boolean Retina { get; set; }
        public int WarehouseStock { get; set; }
        public Boolean News { get; set; }
        public string ProductCode { get; set; }
        public string CameraPixels { get; set; }
        public string Developer { get; set; }
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