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
        public ActionResult Index(string ReleaseYear, params string[] Developers)
        {
            List<CellPhone> model = new List<CellPhone>();

            if (ReleaseYear != null)
            {
                var cellPhones = Db.CellPhones.Where(x => x.Discontinued != true && x.ReleaseYear == ReleaseYear)
                                   .OrderBy(x => x.ReleaseYear)
                                   .ThenBy(x => x.Developer)
                                   .ThenBy(x => x.Name)
                                   .ToList();

                return View(cellPhones);
            }

            if (Developers != null)
            {
                var cellPhones = Db.CellPhones.Where(x => x.Discontinued != true).ToList();
                foreach (var item in Developers)
                {
                    var temp = cellPhones.Where(x => x.Developer == item).ToList();
                    foreach (var item2 in temp)
                    {
                        model.Add(item2);
                    }
                }

                model.OrderBy(x => x.Developer)
                     .ThenBy(x => x.Name);
            }
            else
            {
                model = Db.CellPhones.Where(x => x.Discontinued != true)
                                     .OrderBy(x => x.Developer)
                                     .ThenBy(x => x.Name).ToList();
            }

            

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Product", model);
            }

            return View(model);
        }

        public ActionResult Categories()
        {

            return View();
        }

        public ActionResult CategoriesResult(string Category)
        {
            if (Category == null)
                return RedirectToAction("Categories");

            var model = new List<string>();

            

            if (Category == "Developers")
            {
                var developers = Db.CellPhones.Select(x => x.Developer).Distinct().ToList();
                foreach (var item in developers)
                {
                    model.Add(item);
                }

                model.Sort();
            }
            else
            {
                var releaseYears = Db.CellPhones.Select(x => x.ReleaseYear).Distinct().ToList();
                foreach (var item in releaseYears)
                {
                    model.Add(item);
                }

                model.Sort();
            }

            model.Add(Category);


            return View(model);
        }

        public ActionResult Developers()
        {
            var model = Db.CellPhones.Select(x => x.Developer).Distinct().ToList();

            return View(model);
        }

        public ActionResult ReleaseYear()
        {
            var model = Db.CellPhones.Select(x => x.ReleaseYear).Distinct().ToList();

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