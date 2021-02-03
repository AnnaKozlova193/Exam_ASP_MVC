using MyScore_ASP.Helpers;
using MyScore_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyScore_ASP.Controllers
{
    public class HomeController : Controller
    {
        private ScoreContext db = new ScoreContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Link = "https://shop.metro.ua";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Link = "https://shop.metro.ua";

            return View();
        }

        // создаем странички-категории для отображения товаров
        public ActionResult Milk()
        {
            ViewBag.Link = "https://shop.metro.ua"; 

            ViewBag.Message = "Молочная продукция";

            var products = db.Products;

            return View(products.ToList());

        }
        public ActionResult BabyFood()
        {
            ViewBag.Link = "https://shop.metro.ua";

            ViewBag.Message = "Детское питание";

            var products = db.Products;

            return View(products.ToList());
        }
        public ActionResult Sausages()
        {
            ViewBag.Link = "https://shop.metro.ua";

            ViewBag.Message = "Колбасы";

            var products = db.Products;

            return View(products.ToList());
        }
        public ActionResult Confectionery()
        {
            ViewBag.Link = "https://shop.metro.ua";

            ViewBag.Message = "Кондитерские изделия";

            var products = db.Products;

            return View(products.ToList());
        }
        public ActionResult Bread()
        {
            ViewBag.Link = "https://shop.metro.ua";

            ViewBag.Message = "Хлеб";

            var products = db.Products;

            return View(products.ToList());
        }
        public ActionResult AnimalFeed()
        {
            ViewBag.Link = "https://shop.metro.ua";

            ViewBag.Message = "Корм для животных";

            var products = db.Products;

            return View(products.ToList());
        }
        public ActionResult Grocery() 
        {
            ViewBag.Link = "https://shop.metro.ua";

            ViewBag.Message = "Бакалея";

            var products = db.Products;

            return View(products.ToList());
        }
        public ActionResult Alcohol()
        {
            ViewBag.Link = "https://shop.metro.ua"; 

            ViewBag.Message = "Алкоголь";

            var products = db.Products;

            return View(products.ToList());

        }
        public ActionResult Beverages()
        {
            ViewBag.Link = "https://shop.metro.ua";

            ViewBag.Message = "Напитки";

            var products = db.Products;

            return View(products.ToList());
        }
 
    }
}

