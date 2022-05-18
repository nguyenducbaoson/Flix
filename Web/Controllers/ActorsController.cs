using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
namespace Web.Controllers
{
    public class ActorsController : Controller
    {
        // GET: Actors+
        Movie12Entities db = new Movie12Entities();
        public ActionResult Profile(string CastID = "C1")
        {
            Cast cast = db.Casts.SingleOrDefault(n => n.CastID == CastID);
            if (cast == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cast);
        }
        public ActionResult Index(string CastID = "C1")
        {
            Cast cast = db.Casts.SingleOrDefault(n => n.CastID == CastID);
            if (cast == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cast);
        }
    }
}