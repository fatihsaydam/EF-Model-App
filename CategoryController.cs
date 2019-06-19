using EntityFrameworkModelUygulamasi.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkModelUygulamasi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult IndexCategory()
        {
            var model = db.Categories.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(Categories category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("IndexCategory","Category");
        }

        public ActionResult UpdateCategory(Categories category)
        {
            var guncellenecekKategori = db.Categories.Find(category.CategoryID);
            guncellenecekKategori.CategoryName = category.CategoryName;
            guncellenecekKategori.Description = category.Description;            
            db.SaveChanges();
            return RedirectToAction("IndexCategory", "Category");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Categories.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("UpdateCategory", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekKategori = db.Categories.Find(id);
            if (silinecekKategori==null)
            {
                return HttpNotFound();
            }
            db.Categories.Remove(silinecekKategori);
            db.SaveChanges();
            return RedirectToAction("IndexCategory", "Category");
        }
    }
}