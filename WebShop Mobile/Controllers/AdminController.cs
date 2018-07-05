using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_Mobile.Models;

namespace WebShop_Mobile.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private WebShopMobileDb Db = new WebShopMobileDb();
        private ApplicationDbContext AppDb = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllProducts()
        {
            var model = Db.CellPhones.OrderBy(x => x.Developer)
                                     .ThenBy(x => x.Name).ToList();

            return View(model);
        }

        public ActionResult AllUsers()
        {
            var users = AppDb.Users.ToList();
            var customers = Db.Customers.ToList();

            var model = new List<userViewModel>();

            foreach (var item in users)
            {
                var customer = customers.FirstOrDefault(x => x.EmailAdress == item.Email);
                model.Add(new userViewModel(item, customer));
            }

            return View(model);
        }

        public ActionResult AddAdmin(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(AppDb));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(AppDb));

            var model = AppDb.Users.First(x => x.Id == id);

            var check = UserManager.AddToRole(model.Id, "Admin");

            AppDb.SaveChanges();

            return RedirectToAction("AllUsers");
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(CellPhone product)
        {
            Db.CellPhones.Add(product);

            Db.SaveChangesAsync();

            return RedirectToAction("Index","Product", null);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("AllProducts");

            var model = Db.CellPhones.First(x => x.Id == id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CellPhone product)
        {
            var model = Db.CellPhones.First(x => x.Id == product.Id);

            model.Name = product.Name;
            model.Developer = product.Developer;
            model.Price = product.Price;
            model.ProductCode = product.ProductCode;
            model.ReleaseYear = product.ReleaseYear;
            model.Retina = product.Retina;
            model.WarehouseStock = product.WarehouseStock;
            model.News = product.News;
            model.Discontinued = product.Discontinued;
            model.CameraPixels = product.CameraPixels;
            model.Colors = product.Colors;

            Db.SaveChangesAsync();

            return RedirectToAction("AllProducts");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Db.CellPhones.First(x => x.Id == id).Discontinued = true;
            Db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}