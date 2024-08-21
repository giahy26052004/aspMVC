using huy2.Context;
using huy2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace huy2.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
            hyconEntities db= new hyconEntities();
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {

                return RedirectToAction("Login","User");
           
            }
  
   
            else
            {
                var lstCart = (List<CartModel>)Session["Cart"];
                Order obj = new Order();
                obj.Name = "DonHang" + DateTime.Now.ToString("yyyyMMddHHmmss");
                obj.UserId = int.Parse(Session["idUser"].ToString());
                obj.CreatedOnUtc = DateTime.Now;
                obj.Status = 1;
                db.Order.Add(obj);
                db.SaveChanges();
                int intOrderId = obj.Id;
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                foreach (var cart in lstCart) { 
                    OrderDetail objOrderDetail=new OrderDetail();
                    objOrderDetail.Quantity = cart.Quantity;
                    objOrderDetail.OrderId = intOrderId;
                    objOrderDetail.ProductId=cart.Product.Id;
                    orderDetails.Add(objOrderDetail);
                }
                db.OrderDetail.AddRange(orderDetails);

                @Session["cart"] = null;
                @Session["count"] = 0;
                db.SaveChanges();
            }
            return View();
        }
    }
}