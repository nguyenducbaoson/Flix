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
            return View(movie);
        }
        public ViewResult Cast()
        {
            return View();
        }

    }
}