﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_Mobile.Models;

namespace WebShop_Mobile.Controllers
{
    public class AdminController : Controller
    {

        private WebShopMobileDb Db = new WebShopMobileDb();
        private ApplicationDbContext AppDb = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllProducts()
        {
            var model = Db.CellPhones.ToList();

            return View(model);
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

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

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

            return RedirectToAction("Index");
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