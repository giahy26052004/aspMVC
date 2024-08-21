using huy2.Context;
using huy2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace huy2.Controllers
{
    public class CategoryController : Controller
    {
        hyconEntities db=new hyconEntities();
        // GET: Category
        public ActionResult Index(int Id)
        {
            var category = db.Categories.FirstOrDefault(p => p.Id == Id);
            var products = db.Products.Where(p => p.Categoryid == Id).ToList();
            if (category == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CategoryProductViewModel
            {
                Category = category,
                Products = products
            };
            return View(viewModel);
        }
    }
}