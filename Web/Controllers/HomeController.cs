using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Web.Models;

namespace WebXemPhim.Controllers
{
    public class HomeController : Controller
    {//
        Movie12Entities db = new Movie12Entities();
        public ViewResult Index()
        {

            List<Movie> lstMovie = db.Movies.OrderBy(n => n.Name).ToList();
            return View(db.Movies.ToList());
        }
        //
        public ViewResult GetAllPhim(int? page)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            List<Movie> lstMovie = db.Movies.OrderBy(n => n.Name).ToList();
            return View(lstMovie.ToPagedList(pageNum, pageSize));

        }
        public ViewResult GetMovieByCategory(int? page, int id = 1007)
        {
            int pageSize = 12;
            int pageNum = (page ?? 1);
            List<Movie> lstMovie = db.Movies.Where(n => n.CategoryID == id).ToList();
            ViewBag.TheLoai = db.Categories.SingleOrDefault(n => n.CategoryID == id).NameCategory;
            return View(lstMovie.ToPagedList(pageNum, pageSize));
        }
        public ViewResult GetMovieByCountry(int? page,int id)
        {

            int pageSize = 12;
            int pageNum = (page ?? 1);
            List<Movie> lstMovie = db.Movies.Where(n => n.CountryID == id).ToList();
            ViewBag.QuocGia = db.Countries.SingleOrDefault(n => n.CountryID == id).Name;
            return View(lstMovie.ToPagedList(pageNum, pageSize));
        }
        public PartialViewResult Banner()
        {
            List<Movie> lstMovie = db.Movies.Where(n => n.Isbanner == 1 && n.Active != 1).OrderBy(n => n.Name).ToList();
            ViewBag.lstMovie = db.Movies.ToList();
            return PartialView(lstMovie);
        }
        public PartialViewResult BannerActive()
        {
            List<Movie> lstMovie = db.Movies.Where(n => n.Active == 1).OrderBy(n => n.Name).ToList();
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
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        public JsonResult Calling()
        {
            System.Threading.Thread.Sleep(1000);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
