using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using PagedList;
using PagedList.Mvc;

namespace Web.Controllers
{
    public class TVSeriesController : Controller
    {
        // GET: TVSeries
        Movie12Entities db = new Movie12Entities();
        [HttpGet]
        private List<CTTapPhim> laytap(int count,string MovieID="1")
        {

            return db.CTTapPhims.Where(m => m.ID2 == MovieID).Take(count).ToList();
        }
        public ViewResult DetailTVSeries(string MovieID="1")
        {
            PhimBo movie = db.PhimBoes.SingleOrDefault(n => n.ID == MovieID);
            if (movie == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var Cast = db.Cast_TVSeries.Where(n => n.TVSeriesID == MovieID).ToList();
            ViewData["Actors"] = Cast;
            var Director = db.Director_TVSeries.Where(n => n.TVSeriesID == MovieID).ToList();
            ViewData["Director"] = Director;
            return View(movie);

        }
        public ActionResult Views(int? tap,string MovieID = "1")
        {
            PhimBo movie = db.PhimBoes.SingleOrDefault(n => n.ID == MovieID);
            movie.Viewed += 1;
            UpdateModel(movie);
            db.SaveChanges();
            return RedirectToAction("Watch", "TVSeries", new {MovieID = movie.ID, tap = 1 });
        }
        public ViewResult Watch(int? tap,string MovieID="1")
        {
            int pageSize = 1;
            int pageNum = (tap ?? 1);
            var a = laytap(1000, MovieID);
            PhimBo movie = db.PhimBoes.SingleOrDefault(n => n.ID == MovieID);
            ViewBag.PhimBo = movie;
            var p = db.CTTapPhims.Where(m => m.TapPhim == tap && m.ID2 == MovieID).ToList();
            ViewData["p"] = p;
            return View(a.ToPagedList(pageNum, pageSize));
        }

    }
}