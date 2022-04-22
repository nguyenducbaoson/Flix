using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace WebXemPhim.Controllers
{
    public class MyListController : Controller
    {
        // GET: MyList
        Movie12Entities db = new Movie12Entities();
        public ActionResult Index(string email)
        {
            List<MyList> lst = db.MyLists.Where(m => m.Email == email).ToList();
            if (lst == null)
            {
                ViewBag.lst = "Không có phim nào";
                return null;
            }
            else ViewBag.lst = "DS Phim";
            List<Movie> lstMovie = new List<Movie>();
            foreach (var item in lst)
            {
                Movie m = db.Movies.SingleOrDefault(n => n.MovieID == item.MovieID);

                lstMovie.Add(new Movie() { MovieID = m.MovieID, Name = m.Name, Image = m.Image, Time = m.Time, Rate = m.Rate });
            }
            return View(lstMovie);
        }





    }
}