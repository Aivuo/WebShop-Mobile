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
        public string Colors { get; set; }
        public bool Retina { get; set; }
        public int WarehouseStock { get; set; }
        public bool News { get; set; }
        public string ProductCode { get; set; }
        public string CameraPixels { get; set; }
        public string Developer { get; set; }
        public bool Discontinued { get; set; }
    }
}