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
            var Actor = db.Cast_Movie.Where(n => n.CastID == CastID).ToList();
            ViewData["moviejoined"] = Actor;
            return View(cast);
        }
        public PartialViewResult Moviesjoined(string CastID = "C1")
        {
            var ActorinMovie = db.Cast_Movie.Where(n => n.CastID == CastID).ToList();
            var ActorinTVSeries = db.Cast_TVSeries.Where(n => n.CastID == CastID).ToList();
            ViewData["moviejoined"] = ActorinMovie;
            ViewData["moviejoined2"] = ActorinTVSeries;
            return PartialView();
        }
    }
}