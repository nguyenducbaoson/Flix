using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DirectorController : Controller
    {
        Movie12Entities db = new Movie12Entities();
        // GET: Director
        public ActionResult Profile(string DirectorID="D1")
        {
            Director director = db.Directors.SingleOrDefault(n => n.DirectorID == DirectorID);
            if (director == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var directors = db.Director_Movie.Where(n => n.DriectorID == DirectorID).ToList();
            ViewData["moviejoined"] = directors;
            return View(director);
        }
        public PartialViewResult Moviesjoined(string DirectorID = "D1")
        {
            var DirectorMovie = db.Director_Movie.Where(n => n.DriectorID == DirectorID).ToList();
            var DirectorTVSeries = db.Director_TVSeries.Where(n => n.DirectorID == DirectorID).ToList();
            ViewData["moviejoined"] = DirectorMovie;
            ViewData["moviejoined2"] = DirectorTVSeries;
            return PartialView();
        }
    }
}