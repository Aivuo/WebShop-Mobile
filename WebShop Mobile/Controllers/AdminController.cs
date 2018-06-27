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
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllUsers()
        {

            return View();
        }

        public ActionResult AllProducts()
        {

            return View();
        }

        public ActionResult EditUser(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        public ActionResult EditUser(TestPerson testPerson)
        {

            return RedirectToAction("AllUsers");
        }

        public ActionResult EditProduct(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        public ActionResult EditProduct(TestProduct testProduct)
        {

            return RedirectToAction("AllUsers");
        }
    }
}