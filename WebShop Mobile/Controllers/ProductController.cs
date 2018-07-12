using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
        public ActionResult Index(string ReleaseYear, int? search, string searchString, params string[] Developers)
        {
            var model = Methods.SearchProducts(ReleaseYear, searchString, Developers);

            if (Request.IsAjaxRequest())
            {
                if (search != null)
                    return PartialView("_Product", model);
                else
                    return PartialView(model); 
            }

            return View(model);
        }

        [Authorize]
        public ActionResult AddToCart(int cellId)
        {
            var userName = User.Identity.Name;
            Methods.AddtoCart(cellId, userName);

            return RedirectToAction("Index");
        }

        public ActionResult Cart()
        {
            var user = User.Identity.Name;
            if (user == "")
            {
                return RedirectToAction("Index", "Home", null);
            }
            var customer = Db.Customers.Include("Orders")
                                       .FirstOrDefault(x => x.EmailAdress == user);
            var order = Db.Orders.Include("OrderRows")
                                 .FirstOrDefault(x => x.CustomerId == customer.Id && x.Processed == false);

            if (order != null)
            {
                var cellPhones = Db.CellPhones.Where(x => x.Discontinued == false);
                foreach (var item in order.OrderRows)
                {
                    item.CellPhone = cellPhones.First(x => x.Id == item.CellPhoneId);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView(order);
            }

            return View(order);
        }

        public ActionResult Categories()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }

            return View();
        }

        public ActionResult CategoriesResult(string Category)
        {
            if (Category == null)
                return RedirectToAction("Categories");

            var model = Methods.CategoriesResult(Category);

            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var model = Db.CellPhones.First(x => x.Id == id);

            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }

            return View(model);
        }

        public ActionResult RemoveFromCart(int cellId, int orderId)
        {
            var model = Db.Orders.Include("OrderRows").FirstOrDefault(x => x.Id == orderId);

            var cell = model.OrderRows.FirstOrDefault(x => x.Id == cellId);

            model.OrderRows.Remove(cell);
            Db.OrderRows.Remove(cell);

            if (model.OrderRows.Count == 0)
            {
                Db.Orders.Remove(model);
            }

            Db.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Cart");
            }

            return RedirectToAction("Cart");
        }

        public ActionResult Order(int orderId)
        {
            var model = Db.Orders.Include("OrderRows")
                                 .Include("Customer")
                                 .FirstOrDefault(x => x.Id == orderId);

            foreach (var item in model.OrderRows)
            {
                item.CellPhone = Db.CellPhones.FirstOrDefault(x => x.Id == item.CellPhoneId);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }

            return View(model);
        }

    }
}