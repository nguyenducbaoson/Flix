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
        MovieEntities5 db =new MovieEntities5();
        [HttpPost]
        public ActionResult SignIn(FormCollection f)
        {
            // Kiểm Tra tên đăng nhập và mật khẩu
            string tk = f["taikhoan"].ToString();
            string mk = f["matkhau"].ToString();
            User user = db.Users.SingleOrDefault(n => n.Email == tk && n.Password == mk);
            if(user !=null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.thongbao = "login unsuccessful";
                return View();
            }

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
        public ActionResult Facebookcallback(string code)
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
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string fullName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;
                var user = new User();
                user.Email = email;
                user.FullName = email;
                var resultInsert = InsertforFacebook(user);
                if (resultInsert == "")
                {
                    return Redirect("/");
                }
            }
            return Redirect("/");

        }
        public string InsertforFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.FullName == entity.FullName);
            if (user ==null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.Email;
            }
            else
            {
                return user.Email;
            }
        }
    }
}