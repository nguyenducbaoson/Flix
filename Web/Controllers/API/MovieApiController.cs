using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Web.Models;

namespace Web.Controllers.API
{
    public class MovieApiController : ApiController
    {
        Movie12Entities db = new Movie12Entities();
        // GET api/values
        [HttpGet]
        public List<Movie> GetAll()
        {
            var movie = db.Movies.ToList();
            var lstMovie = new List<Movie>();
            foreach (var item in movie)
            {
                lstMovie.Add(new Movie()
                {
                    MovieID = item.MovieID,
                    Name = item.Name,
                    Image = item.Image,
                    Actor = item.Actor,
                    Description = item.Description,
                    Directors = item.Directors,
                    Time = item.Time,
                    Year = item.Year,
                    Country = item.Country
                });
            }
            return lstMovie;
        }
        [HttpGet]
        [Route("api/MovieApi/Top")]
        public List<Movie> GetTop()
        {
            int i = 0;
            var movie = db.Movies.OrderByDescending(m => m.Viewed).ToList();
            var lstMovie = new List<Movie>();
            foreach (var item in movie)
            {
                if (i == 10) break;
                lstMovie.Add(new Movie()
                {
                    MovieID = item.MovieID,
                    Name = item.Name,
                    Image = item.Image,
                    Actor = item.Actor,
                    Viewed=item.Viewed,
                    Description = item.Description,
                    Directors = item.Directors,
                    Time = item.Time,
                    Year = item.Year,
                    Country = item.Country
                    
                });
                i++;
            }
            return lstMovie;
        }
        [HttpGet]
        public Movie GetMovieById(string id)
        {
            var item = db.Movies.SingleOrDefault(n => n.MovieID == id);


            Movie m = new Movie()
            {
                MovieID = item.MovieID,
                Name = item.Name,
                Image = item.Image,
                Description=item.Description,
                Actor = item.Actor,
                Rate =item.Rate,
                TrailerLink =item.TrailerLink,
                MovieLink=item.MovieLink,
                Directors = item.Directors,
                Time = item.Time,
                Year = item.Year,
                CountryID = item.CountryID,
                CategoryID=item.CategoryID

            };
            return m;
        }
        [HttpPost]
        public JsonResult<bool> insert(FilmRequestModel filmRequestModel)
        {
            try
            {

                Movie movie = db.Movies.SingleOrDefault(n => n.MovieID == filmRequestModel.Id);
                if (movie != null)
                {
                    return Json(false);
                }
                Movie m = new Movie();
                m.MovieID = filmRequestModel.Id;
                m.Name = filmRequestModel.Name;
                m.CategoryID = filmRequestModel.category;
                m.Time = filmRequestModel.time;
                if (filmRequestModel.image != null)
                {
                    string[] str = filmRequestModel.image.Split('\\');

                    m.Image = str[str.Length - 1];
                }
                else
                {
                    m.Image = null;
                }
                m.MovieLink = filmRequestModel.linkmovie;
                m.TrailerLink = filmRequestModel.linktrailer;
                m.Year = filmRequestModel.year;
                m.CountryID = filmRequestModel.country;
                m.Description = filmRequestModel.description;
                db.Movies.Add(m);
                db.SaveChanges();
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        [HttpPut]
        public bool update(string id, string name,string image,int category,string time,string linkmovie,string linktrailer,int year,int country,string description)
        {
            try
            {
                Movie movie = db.Movies.SingleOrDefault(n => n.MovieID == id);
                if (movie == null)
                {
                    return false;
                }
                string anh = movie.Image;
                movie.MovieID = id;
                movie.Name = name;
                movie.CategoryID = category;
                movie.Time = time;
                if (image != null) { 
                string[] str = image.Split('\\');

                movie.Image = str[str.Length-1];}
                else
                {
                    movie.Image = anh;
                }
                movie.MovieLink = linkmovie;
                movie.TrailerLink = linktrailer;
                movie.Year = year;
                movie.CountryID = country;
                movie.Description = description;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete]
        public bool delete(string id)
        {
            Movie m = db.Movies.SingleOrDefault(n => n.MovieID == id);
            if (m == null)
            {
                return false;
            }
            db.Movies.Remove(m);
            db.SaveChanges();
            return true;
        }
        //public List<Movie> GetMovie(string id)
        //{
        //    var list = from p in db.Movies
        //               where SqlMethods.Like(p.MovieID, "%" + id + "%")
        //               select p;
        //    return list.ToList();
        //}
    }
}
