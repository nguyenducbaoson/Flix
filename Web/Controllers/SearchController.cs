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
    public class SearchController : Controller
    {
        // GET: Search
        Movie5Entities1 db = new Movie5Entities1();
        public ActionResult Search(int ?page,string SearchString,string currentFilter)
        {
            var result = new List<Movie>();
            if(SearchString!=null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if(!string.IsNullOrEmpty(SearchString))
            {
               result = db.Movies.Where(n => n.Name.Contains(SearchString) == true).ToList();
            }
            else
            {
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 12;
            int pageNum = (page ?? 1);
            result = result.OrderByDescending(n => n.MovieID).ToList();
            return View(result.ToPagedList(pageNum, pageSize));
        }
    }
}