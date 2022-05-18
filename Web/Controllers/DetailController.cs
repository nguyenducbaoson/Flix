using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DetailController : Controller
    {
        Movie12Entities db = new Movie12Entities();
        // GET: Detail
        [HttpGet]
        public ViewResult DetailMovie(string MovieID="Movie1")
        {
            Movie movie = db.Movies.SingleOrDefault(n => n.MovieID == MovieID);
            if (movie == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //var casts = from a in db.Casts
            //            join b in db.Cast_Movie on a.CastID equals b.CastID
            //            join c in db.Movies on b.IDMovie equals c.MovieID
            //            where MovieID == c.MovieID
            //            select a.FullName;
            //ViewData["Actors"] = casts;
            //return View(movie);
            //List<Cast_Movie> a = db.Cast_Movie.Where(n => n.IDMovie == MovieID).Take(1).SingleOrDefault();
            //var b = db.Movies.Where(n => n.MovieID == MovieID).ToList();
            //List<Cast> casts = db.Casts.Where(n => n.CastID == a.).ToList();
            //ViewData["Actors"] = casts;
            var Cast = db.Cast_Movie.Where(n => n.IDMovie == MovieID).ToList();
            ViewData["Actors"] = Cast;
            var Director = db.Director_Movie.Where(n => n.IDMovie == MovieID).ToList();
            ViewData["Director"] = Director;
            return View(movie);
        }
        public ActionResult Profile(string DirectorID = "D1")
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
        public ViewResult Cast()
        {
            return View();
        }

    }
}