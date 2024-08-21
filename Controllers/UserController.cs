using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using huy2.Context;

namespace huy2.Controllers

{
    public class UserController : Controller
    {
        hyconEntities obj = new hyconEntities();
        // GET: User

        public ActionResult Register()
        {

            return View();
        }
   
 
        [HttpPost]
        public ActionResult Register(Users _user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var check = obj.Users.FirstOrDefault(s => s.Email == _user.Email);
                    if (check == null)
                    {
                        _user.Password = GetMD5(_user.Password);
                        obj.Configuration.ValidateOnSaveEnabled = false;
                        obj.Users.Add(_user);
                        obj.SaveChanges();
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.error = "Email already exists";
                        return View();
                    }

                    
                }

            }
            catch (Exception) {
                throw;
            }

            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = obj.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().idUser;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}