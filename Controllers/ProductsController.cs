using huy2.Models;
using huy2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace huy2.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            using (hyconEntities db = new hyconEntities())
            {
                var products = db.Products.ToList();
                return View(products);
            }
        }
        public ActionResult Index1()
        {
            using (hyconEntities db = new hyconEntities())
            {
                var products = db.Products.ToList();
                return View(products);
            }
        }
        public ActionResult Detail(int Id)
        {
            using (hyconEntities db = new hyconEntities())
            {
                var product = db.Products.FirstOrDefault(p => p.Id == Id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
        }
    }

}