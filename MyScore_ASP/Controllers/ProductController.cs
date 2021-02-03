using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyScore_ASP;
using MyScore_ASP.Models;
using MyScore_ASP.Helpers;

namespace MyScore_ASP.Controllers
{
    public class ProductController : Controller
    {
        private ScoreContext db = new ScoreContext();

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Table_Matufactur);
            return View(products.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.IdCategory = new SelectList(db.Categories, "Id", "NameCategory");
            ViewBag.IdManufacturer = new SelectList(db.Table_Matufactur, "Id", "NameManufacturer");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameProduct,Price,Photo,IdCategory,IdManufacturer")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategory = new SelectList(db.Categories, "Id", "NameCategory", product.IdCategory);
            ViewBag.IdManufacturer = new SelectList(db.Table_Matufactur, "Id", "NameManufacturer", product.IdManufacturer);
            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "Id", "NameCategory", product.IdCategory);
            ViewBag.IdManufacturer = new SelectList(db.Table_Matufactur, "Id", "NameManufacturer", product.IdManufacturer);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameProduct,Price,Photo,IdCategory,IdManufacturer")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "Id", "NameCategory", product.IdCategory);
            ViewBag.IdManufacturer = new SelectList(db.Table_Matufactur, "Id", "NameManufacturer", product.IdManufacturer);
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}


