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

            if (Request.IsAjaxRequest() || search == 2)
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

            if (Request.IsAjaxRequest())
            {
                return RedirectToAction("Index", new { search = 2 });
            }

            return RedirectToAction("Index");
        }

        public ActionResult Cart(bool remove = false)
        {
            var user = User.Identity.Name;
            if (user == "")
            {
                return PartialView("_EmptyCart");
            }
            var order = Methods.FindCartOrder(user);

            if (Request.IsAjaxRequest() || remove)
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

        public ActionResult Checkout()
        {
            var user = User.Identity.Name;
            var order = Methods.FindCartOrder(user);

            //order.Processed = true;
            //Db.SaveChanges();

            if (Request.IsAjaxRequest())
                return PartialView(order);

            return View(order);
        }

        [HttpPost]
        public ActionResult CheckOut(float total, int orderId, string payment)
        {
            Methods.PaymentMethod(payment, total);

            return RedirectToAction("Receipt", "Pdf", new {orderId, payment, total});
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
                return RedirectToAction("Cart", new {remove = true});
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