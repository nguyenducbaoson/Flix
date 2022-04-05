﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        Movie5Entities1 db = new Movie5Entities1();
        public ViewResult Index()
        {
            List<Movie> lstMovie = db.Movies.OrderBy(n => n.Name).ToList();
            return View(db.Movies.ToList());
        }
        public PartialViewResult Banner()
        {
            List<Movie> lstMovie = db.Movies.Where(n => n.Isbanner == 1 && n.Active!=1 ).OrderBy(n => n.Name).ToList();
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
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        public PartialViewResult Pay()
        {
            return PartialView();
        }
    }
}