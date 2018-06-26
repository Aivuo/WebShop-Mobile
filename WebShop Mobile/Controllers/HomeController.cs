using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_Mobile.Models;

namespace WebShop_Mobile.Controllers
{
    public class HomeController : Controller
    {

        TestDb TestDb = new TestDb();
        ApplicationDbContext AppDb = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowPeople()
        {
            var model = AppDb.Users.ToList();
            //var model = TestDb.TestPeople.ToList();

            var model2 = new List<CustomerViewModel>();

            foreach (var item in model)
            {
                var customer = TestDb.TestPeople.FirstOrDefault(x => x.UserConnectionId == item.Id);
                //var user = AppDb.Users.First(x => x.Id == item.UserConnectionId);
                if (customer != null)
                {
                    model2.Add(new CustomerViewModel(customer, item));
                }
            }

            return View(model2);
        }
    }
}