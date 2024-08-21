using huy2.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.Entity;

using System.Web.Mvc;

namespace huy2.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: product
        hyconEntities db = new hyconEntities();
        public ActionResult Index()
        {
            
            var products = db.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Products objProduct)
        {
            try
            {
                if (objProduct.ImageUpload != null && !string.IsNullOrEmpty(objProduct.ImageUpload.FileName))
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extention = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + extention;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                else
                {
                    throw new ArgumentException("Tệp tải lên không hợp lệ.");
                }

                db.Products.Add(objProduct);
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
            var objProduct = db.Products.Where(n=>n.Id == id).FirstOrDefault(); 
            return View(objProduct);
        }
        // GET: category
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct=db.Products.Where(p=>p.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Products objProduct)
        {
            var Product=db.Products.Where(n=>n.Id==objProduct.Id).FirstOrDefault();
            db.Products.Remove(Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = db.Products.Where(p=>p.Id==id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(Products objProduct)
        {
            if (objProduct.ImageUpload != null && !string.IsNullOrEmpty(objProduct.ImageUpload.FileName))
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extention = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + extention;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            else
            {
                throw new ArgumentException("Tệp tải lên không hợp lệ.");
            }
            db.Entry(objProduct).State=EntityState.Modified;
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