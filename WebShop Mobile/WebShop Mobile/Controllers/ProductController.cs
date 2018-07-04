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
        private WebShopMobileDb Db = new WebShopMobileDb();
        private ApplicationDbContext AppDb = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            var model = Db.CellPhones.Where(x => x.Discontinued != true).ToList();

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var model = Db.CellPhones.First(x => x.Id == id);

            return View(model);
        }
    }
}