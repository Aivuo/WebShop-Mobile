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
        private TestDb TestDb = new TestDb();
        private ApplicationDbContext AppDb = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(_Products);
        }

        public ActionResult AllProducts()
        {

            return View(_Products);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var model = _Products.First(x => x.Id == id);

            return View(model);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(TestProduct product)
        {
            _Products.Add(product);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var model = _Products.First(x => x.Id == id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TestProduct testProduct)
        {
            var model = _Products.First(x => x.Id == testProduct.Id);

            model.Name = testProduct.Name;
            model.Manufacturer = testProduct.Manufacturer;
            model.Price = testProduct.Price;
            model.ProductCode = testProduct.ProductCode;
            model.ReleaseYear = testProduct.ReleaseYear;
            model.Retina = testProduct.Retina;
            model.ScreenResolution = testProduct.ScreenResolution;
            model.Stock = testProduct.Stock;
            model.Frontpage = testProduct.Frontpage;
            model.Discontinued = testProduct.Discontinued;
            model.CameraMP = testProduct.CameraMP;
            model.Colors = testProduct.Colors;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            _Products.First(x => x.Id == id).Discontinued = true;


            return RedirectToAction("Index");
        }


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
                Colors = {TestProduct.Color.Pink, TestProduct.Color.Gold, TestProduct.Color.Obsidian},
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