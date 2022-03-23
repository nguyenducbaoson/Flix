using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MovieEntities4 db =new MovieEntities4();
        [HttpPost]
        public ActionResult SignIn(FormCollection f)
        {
            // Kiểm Tra tên đăng nhập và mật khẩu
            string tk = f["taikhoan"].ToString();
            string mk = f["matkhau"].ToString();
            User user = db.Users.SingleOrDefault(n => n.UserName == tk && n.Password == mk);
            return RedirectToAction("Index","Home");
        }
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Register2()
        {
            return View();
        }
        public ActionResult CreditCard()
        {
            return View();
        }
    }
}