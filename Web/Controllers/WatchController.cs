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
        Movie5Entities1 db = new Movie5Entities1();
        public ViewResult Index(string MovieID = "Movie1")
        {
            Movie movie = db.Movies.SingleOrDefault(n => n.MovieID == MovieID);
            if (movie == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(movie);

        }
    }
}