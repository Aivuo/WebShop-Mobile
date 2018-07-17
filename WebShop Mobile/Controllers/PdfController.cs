using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_Mobile.Models;

namespace WebShop_Mobile.Controllers
{
    public class PdfController : Controller
    {
        // GET: Pdf
        public ActionResult Receipt(int orderId, string payment, float total)
        {
            WebShopMobileDb Db = new WebShopMobileDb();
            var user = User.Identity.Name;

            var model = Methods.FindCartOrder(user);
            var customer = Db.Customers.FirstOrDefault(x => x.EmailAdress == user);

            var model2 = Db.Orders.FirstOrDefault(x => x.Id == model.Id);
            model2.Processed = true;
            Db.SaveChanges();

            model.OrderDate = DateTime.Now.ToShortDateString();
            var reciept = new RecieptViewModel(model, customer, payment, total);

            return Pdf(reciept);
        }

        protected ActionResult Pdf()
        {
            return Pdf(null, null, null);
        }

        protected ActionResult Pdf(string fileDownloadName)
        {
            return Pdf(fileDownloadName, null, null);
        }

        protected ActionResult Pdf(string fileDownloadName, string viewName)
        {
            return Pdf(fileDownloadName, viewName, null);
        }

        protected ActionResult Pdf(object model)
        {
            return Pdf(null, null, model);
        }

        protected ActionResult Pdf(string fileDownloadName, object model)
        {
            return Pdf(fileDownloadName, null, model);
        }

        protected ActionResult Pdf(string fileDownloadName, string viewName, object model)
        {
            // Based on View() code in Controller base class from MVC
            if (model != null)
            {
                ViewData.Model = model;
            }
            PdfResult pdf = new PdfResult()
            {
                FileDownloadName = fileDownloadName,
                ViewName = viewName,
                ViewData = ViewData,
                TempData = TempData,
                ViewEngineCollection = ViewEngineCollection
            };
            return pdf;
        }
    }
}