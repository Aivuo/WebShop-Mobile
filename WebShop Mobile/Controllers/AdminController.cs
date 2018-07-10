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

            var model = new List<UserViewModel>();

            foreach (var item in users)
            {
                var customer = customers.FirstOrDefault(x => x.EmailAdress == item.Email);
                model.Add(new UserViewModel(item, customer));
            }

            return View(model);
        }

        public ActionResult DetailsUser(string email)
        {
            var user = AppDb.Users.FirstOrDefault(x => x.Email == email);
            var customer = Db.Customers.FirstOrDefault(x => x.EmailAdress == email);

            var model = new UserViewModel(user, customer);

            return View(model);
        }

        public ActionResult EditUser(string email)
        {
            var user = AppDb.Users.FirstOrDefault(x => x.Email == email);
            var customer = Db.Customers.FirstOrDefault(x => x.EmailAdress == email);

            var model = new UserViewModel(user, customer);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel userView)
        {
            var user = AppDb.Users.FirstOrDefault(x => x.Email == userView.Email);
            var customer = Db.Customers.FirstOrDefault(x => x.EmailAdress == userView.Email);

            user.Email = userView.Email;
            customer.EmailAdress = userView.Email;

            user.EmailConfirmed = userView.EmailConfirmed;

            user.PhoneNumber = userView.PhoneNumber;
            customer.PhoneNumber = userView.PhoneNumber;

            user.PhoneNumberConfirmed = userView.PhoneNumberConfirmed;

            customer.Firstname = userView.Firstname;
            customer.Lastname = userView.Lastname;

            customer.BillingAdress = userView.BillingAdress;
            customer.BillingCity = userView.BillingCity;
            customer.BillingZip = userView.BillingZip;

            customer.DeliveryAdress = userView.DeliveryAdress;
            customer.DeliveryCity = userView.DeliveryCity;
            customer.DeliveryZip = userView.DeliveryZip;

            user.LockoutEnabled = userView.LockoutEnabled;

            if (userView.UserRoles != null)
            {
                foreach (var item in userView.UserRoles)
                {
                    var roleId = AppDb.Roles.FirstOrDefault(x => x.Name == item).Id;
                    var role = user.Roles.FirstOrDefault(x => x.RoleId == roleId);
                    user.Roles.Remove(role);
                }
            }

            AppDb.SaveChanges();
            Db.SaveChanges();

            return RedirectToAction("AllUsers");
        }

        public ActionResult AddAdmin(string email)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(AppDb));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(AppDb));

            var model = AppDb.Users.FirstOrDefault(x => x.Email == email);

            if (model != null)
            {
                var check = UserManager.AddToRole(model.Id, "Admin");

                AppDb.SaveChanges();
            }

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