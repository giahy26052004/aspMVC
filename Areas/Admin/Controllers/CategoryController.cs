using huy2.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace huy2.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
      
            hyconEntities db = new hyconEntities();
            public ActionResult Index()
            {

                var category = db.Categories.ToList();
                return View(category);
            }
            [HttpGet]
            public ActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Create(Categories objProduct)
            {
                try
                {
                    db.Categories.Add(objProduct);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log lỗi nếu có
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                    return RedirectToAction("Index");
                    throw;
                }
            }
            [HttpGet]
            public ActionResult Details(int id)
            {
                var objProduct = db.Categories.Where(n => n.Id == id).FirstOrDefault();
                return View(objProduct);
            }
            // GET: category
            [HttpGet]
            public ActionResult Delete(int id)
            {
                var objProduct = db.Categories.Where(p => p.Id == id).FirstOrDefault();
                return View(objProduct);
            }
            [HttpPost]
            public ActionResult Delete(Categories objProduct)
            {
                var Product = db.Categories.Where(n => n.Id == objProduct.Id).FirstOrDefault();
                db.Categories.Remove(Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            [HttpGet]
            public ActionResult Edit(int id)
            {
                var objProduct = db.Products.Where(p => p.Id == id).FirstOrDefault();
                return View(objProduct);
            }
            [HttpPost]
            public ActionResult Edit(Categories objProduct)
            {
              
                db.Entry(objProduct).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            public ActionResult Category()
            {
                hyconEntities db = new hyconEntities();
                var Category = db.Categories.ToList();
                return View(Category);
            }

    }
}