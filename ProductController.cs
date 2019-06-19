using EntityFrameworkModelUygulamasi.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkModelUygulamasi.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult IndexProduct()
        {
            var model = db.Products.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Products product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("IndexProduct","Product");
        }

        public ActionResult UpdateProduct(Products product)
        {
            var guncellenecekUrun = db.Products.Find(product.ProductID);
            guncellenecekUrun.ProductName = product.ProductName;
            guncellenecekUrun.UnitPrice = product.UnitPrice;
            guncellenecekUrun.UnitsInStock = product.UnitsInStock;
            db.SaveChanges();
            return RedirectToAction("IndexProduct", "Product");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Products.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("UpdateProduct", model);
        }
        
        public ActionResult Sil(int id)
        {
            var model = db.Products.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.Products.Remove(model);
            db.SaveChanges();
            return RedirectToAction("IndexProduct","Product");
        }
    }
}