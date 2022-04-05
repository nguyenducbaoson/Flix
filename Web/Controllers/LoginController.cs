using Facebook;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        Movie5Entities1 db =new Movie5Entities1();
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string email = f["txtemail1"].ToString();
            Session["email"] = email;
            if (string.IsNullOrEmpty(email))
            {
                ViewData["Error"] = "You must enter your email";
            }
            else if (!string.IsNullOrEmpty(email))
            {
                User user = db.Users.SingleOrDefault(n => n.Email == email);
                if (user != null)
                {
                    ViewData["Error2"] = "This email is already registered";
                }
                else
                {
                    return RedirectToAction("Register", "Login",new {email});
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(FormCollection f)
        {
            // Kiểm Tra tên đăng nhập và mật khẩu
            string tk = f["taikhoan"].ToString();
            string mk = f["matkhau"].ToString();
            if(string.IsNullOrEmpty(tk))
            {
                ViewData["Error"] = "You must enter your email";
            }
            else if(string.IsNullOrEmpty(mk))
            {
                ViewData["Error2"] = "You must enter your password";
            }
            else
            {
                User user = db.Users.SingleOrDefault(n => n.Email == tk && n.Password == mk);
                if (user != null)
                {
                    if (user.Permission == false)
                    {
                        Session["User"] = user;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                    }

                }
                else
                {
                    ViewBag.thongbao = "login unsuccessful";
                    return View();
                }
            }
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult Register(string email,FormCollection f)
        {
            ViewData["email"] = email;
            string pass = f["password"];
            if (string.IsNullOrEmpty(pass))
            {
                ViewData["error"] = "you must enter a password";
            }
            else
            {
                User tk = new User();
                tk.Email = (string)Session["email"];
                tk.Password = pass;
                tk.Permission = false;
                tk.FullName = (string)Session["email"];
                db.Users.Add(tk);
                db.SaveChanges();
                return RedirectToAction("Register2");
            }
            return View();
        }
        public ActionResult LoginFacebook()
        {
           
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });
            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult Facebookcallback(string code, User tk)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });
            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string fullName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;
                string aaaaaaaaa = firstname + "@321dSDFdgb";
                var user = db.Users.ToList();
                int kt = 0;
                foreach (var item in user)
                {
                    if (item.Email == aaaaaaaaa)
                        kt = 1;
                }
                if (kt == 1)
                {
                    @Session["ten"] = firstname;
                    @Session["TK"] = aaaaaaaaa;
                    @Session["quyen"] = false;
                }
                else
                {
                    tk.Email = firstname + "@321dSDFdgb";
                    tk.FullName = firstname;
                    tk.Password = "12312ABC@312jidqjv";
                    tk.Permission = false;
                    db.Users.Add(tk);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register2()
        {
            return View();
        }
        public ActionResult CreditCard()
        {
            return View();
        }
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("Facebookcallback");
                return uriBuilder.Uri;
            }
        }
   
        public ActionResult DangXuat()
        {
            Session["User"] = null;
            return RedirectToAction("Index","Home");

        }
        public ActionResult Landing()
        {
            return View();
        }
    }
}