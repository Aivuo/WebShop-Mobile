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
        public ActionResult Index(string ReleaseYear, params string[] Developers)
        {

            var model = Methods.SearchProducts(ReleaseYear, Developers);
            

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Product", model);
            }

            return View(model);
        }

        [Authorize]
        public ActionResult AddToCart(int cellId)
        {
            var user2 = User.Identity.Name;
            var cellPhone = Db.CellPhones.FirstOrDefault(x => x.Id == cellId);
            var user = AppDb.Users.FirstOrDefault(x => x.Email == user2);
            var customer = Db.Customers.Include("Orders").FirstOrDefault(x => x.EmailAdress == user.Email);

            var order = new Order();

            if (customer.Orders == null || customer.Orders.FirstOrDefault(x => x.Processed == false) == null)
            {
                order = new Order
                {
                    CustomerId = customer.Id,
                    Customer = customer,
                    OrderDate = DateTime.Now.ToShortDateString(),
                    Processed = false
                };

                customer.Orders.Add(order);
            }else
            {
                //order = customer.Orders.FirstOrDefault(x => x.Processed == false);
                order = Db.Orders.Include("OrderRows").FirstOrDefault(x => x.CustomerId == customer.Id && x.Processed == false);
            }

            var orderRow = new OrderRow
            {
                CellPhoneId = cellPhone.Id,
                CellPhone = cellPhone,
                Price = cellPhone.Price,
                Date = order.OrderDate,
                OrderId = order.Id,
                Order = order
            };

            order.OrderRows.Add(orderRow);

            Db.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult Cart()
        {
            var user = User.Identity.Name;
            if (user == "")
            {
                return RedirectToAction("Index", "Home", null);
            }
            var customer = Db.Customers.Include("Orders").FirstOrDefault(x => x.EmailAdress == user);
            var order = Db.Orders.Include("OrderRows").FirstOrDefault(x => x.CustomerId == customer.Id && x.Processed == false);

            if (order != null)
            {
                var cellPhones = Db.CellPhones.Where(x => x.Discontinued == false);
                foreach (var item in order.OrderRows)
                {
                    item.CellPhone = cellPhones.First(x => x.Id == item.CellPhoneId);
                }
            }

            return View(order);
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
                var developers = Db.CellPhones.Select(x => x.Developer)
                                              .Distinct().ToList();
                foreach (var item in developers)
                {
                    model.Add(item);
                }

                model.Sort();
            }
            else
            {
                var releaseYears = Db.CellPhones.Select(x => x.ReleaseYear)
                                                .Distinct().ToList();

                foreach (var item in releaseYears)
                {
                    model.Add(item);
                }

                model.Sort();
            }

            model.Add(Category);


            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var model = Db.CellPhones.First(x => x.Id == id);

            return View(model);
        }

        public ActionResult Developers()
        {
            var model = Db.CellPhones.Select(x => x.Developer)
                                     .Distinct().ToList();

            return View(model);
        }

        public ActionResult AddToBasket()
        {

            return View(); //Måste ändras
        }

        public ActionResult ReleaseYear()
        {
            var model = Db.CellPhones.Select(x => x.ReleaseYear)
                                     .Distinct().ToList();

            return View(model);
        }


    }
}