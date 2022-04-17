using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class PayController : Controller
    {
        Movie12Entities db = new Movie12Entities();
        // GET: Pay
        public PartialViewResult Pay()
        {
            Price Basic = db.Prices.Where(n => n.IDPrice == 1).SingleOrDefault();
            Price Premium = db.Prices.Where(n => n.IDPrice == 2).SingleOrDefault();
            Price Vip = db.Prices.Where(n => n.IDPrice == 3).SingleOrDefault();
            ViewBag.basic = Basic;
            ViewBag.Premium = Premium;
            ViewBag.Vip = Vip;
            return PartialView();
        }
        public ActionResult ChoosePrice(int IDPrice,string user)
        {
            //if(string.IsNullOrEmpty(user))
            //{
            //    return PartialView("SignIn", "Login");
            //}
            //else
            //{
                TimeSpan aInterval = new System.TimeSpan(720, 0, 0);
                User a = db.Users.Where(n => n.Email.Equals(user)).SingleOrDefault();
                Pay pay = new Pay();
                pay.IDPay = Guid.NewGuid();
                pay.Email = a.Email;
                pay.IDPrice = IDPrice;
                pay.Datedinscription = DateTime.Now;
                pay.Datedexpiration = DateTime.Now + aInterval;
                db.Pays.Add(pay);
                db.SaveChanges();
                a.IDPay = pay.IDPay;
                db.SaveChanges();
            Session["Pay"] = a.IDPay;
            return RedirectToAction("Index", "Home");
            //}
            return View();
        }
        public PartialViewResult Load()
        {
            return PartialView();
        }
    }
}