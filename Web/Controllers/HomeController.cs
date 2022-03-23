using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        MovieEntities4 db = new MovieEntities4();
        public ViewResult Index()
        {
            List<Movie> lstMovie = db.Movies.OrderBy(n => n.Name).ToList();
            return View(db.Movies.ToList());
        }
        public PartialViewResult Banner()
        {
            List<Movie> lstMovie = db.Movies.Where(n => n.Isbanner == 1 && n.Active!=1).OrderBy(n => n.Name).ToList();
            ViewBag.lstMovie = db.Movies.ToList();
            return PartialView(lstMovie);
        }
        public PartialViewResult BannerActive()
        {
            List<Movie> lstMovie = db.Movies.Where(n => n.Active ==1).OrderBy(n => n.Name).ToList();
            ViewBag.lstMovie = db.Movies.ToList();
            return PartialView(lstMovie);
        }
        public PartialViewResult Category1()
        {
            List<Movie> lstMovie = db.Movies.Where(n => n.CategoryID == 1007).OrderBy(n => n.Name).ToList();
            ViewBag.lstMovie = db.Movies.ToList();
            return PartialView(lstMovie);
        }
        public PartialViewResult Category2()
        {
            List<Movie> lstMovie = db.Movies.Where(n => n.CategoryID == 1020).OrderBy(n => n.Name).ToList();
            ViewBag.lstMovie = db.Movies.ToList();
            return PartialView(lstMovie);
        }
        public PartialViewResult Category3()
        {
            List<Movie> lstMovie = db.Movies.Where(n => n.CategoryID == 1021).OrderBy(n => n.Name).ToList();
            ViewBag.lstMovie = db.Movies.ToList();
            return PartialView(lstMovie);
        }
        public ViewResult DetailMovie(string MovieID = "1")
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