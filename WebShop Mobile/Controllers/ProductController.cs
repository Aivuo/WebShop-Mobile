using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_Mobile.Models;

namespace WebShop_Mobile.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {


            return View(_Products);
        }

        //public PartialViewResult Products()
        //{

        //    return PartialView(_Products);
        //}


        static List<TestProduct> _Products = new List<TestProduct>{
            new TestProduct
            {
                Id = 0,
                Name = "Iphone X",
                ReleaseYear = "2018",
                Price = 7000,
                Colors = {TestProduct.Color.Blue, TestProduct.Color.Green, TestProduct.Color.Red},
                Manufacturer = "Apple",
                ScreenResolution = "2436 x 1125",
                Stock = 12,
                Retina = true,
                CameraMP = "12MP",
                Frontpage = true,
                ProductCode = "MQAC2QN/A",
                Discontinued = false
            },
            new TestProduct
            {
                Id = 1,
                Name = "Iphone XI",
                ReleaseYear = "2019",
                Price = 8000,
                Colors = {TestProduct.Color.Blue, TestProduct.Color.Green, TestProduct.Color.Red},
                Manufacturer = "Apple",
                ScreenResolution = "2436 x 1125",
                Stock = 0,
                Retina = true,
                CameraMP = "15MP",
                Frontpage = true,
                ProductCode = "MQAD2QZ/A",
                Discontinued = false
            },
            new TestProduct
            {
                Id = 2,
                Name = "Galaxy S9",
                ReleaseYear = "2018",
                Price = 7000,
                Colors = {TestProduct.Color.Blue, TestProduct.Color.Green, TestProduct.Color.Red},
                Manufacturer = "Samsung",
                ScreenResolution = "2436 x 1125",
                Stock = 8,
                Retina = true,
                CameraMP = "11MP",
                Frontpage = true,
                ProductCode = "GOITND/A",
                Discontinued = false
            }



        };
    }
}