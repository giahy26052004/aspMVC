
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using huy2.Context;
using huy2.Models;
namespace huy2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
             
        {
            hyconEntities db = new hyconEntities();
            var products = db.Products.ToList();
            var category = db.Categories.ToList();
            var Model = new HomeModels
            {
                Products = products,
                Categories = category
            };
            return View(Model);
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

      

    }
}