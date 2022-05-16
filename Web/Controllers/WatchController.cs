using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class WatchController : Controller
    {
        // GET: Watch
        Movie12Entities db = new Movie12Entities();
        public ViewResult Index(string MovieID = "Movie1")
        {
            Movie movie = db.Movies.SingleOrDefault(n => n.MovieID == MovieID);
                movie.Viewed += 1;
                db.SaveChanges();
                return View(movie);
            

        }
    }
}