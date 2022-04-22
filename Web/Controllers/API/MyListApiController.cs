using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Models;

namespace Web.Controllers.API
{
    public class MyListApiController : ApiController
    {
        Movie12Entities db = new Movie12Entities();
        [HttpPost]
        public bool Themlist(string email, string id)
        {
            if (email == null || id == null)
                return false;
            email = email.Replace(" ", "");
            id = id.Replace(" ", "");
            List<MyList> ml = db.MyLists.Where(n => n.Email == email && n.MovieID == id).ToList();
            
            
            var mv = db.Movies.SingleOrDefault(n => n.MovieID == id);
            if (ml.Count == 0)
            {
                MyList l = new MyList();
                l.Email = email;
                l.MovieID = id;
                db.MyLists.Add(l);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
