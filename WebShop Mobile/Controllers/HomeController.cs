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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebShopMobileDb Db = new WebShopMobileDb();

            var model = Db.CellPhones.Where(x => x.News == true && x.Discontinued == false).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }

            return View(model);
        }

        public ActionResult About()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }

            return View();
        }
    }
}