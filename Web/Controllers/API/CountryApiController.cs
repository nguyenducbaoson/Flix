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
    public class CountryApiController : ApiController
    {
        Movie12Entities db = new Movie12Entities();
        [HttpGet]
        public List<Country> GetCountry()
        {
            var lstCountry = new List<Country>();
            foreach (var item in db.Countries.ToList())
            {
                lstCountry.Add(new Country() { CountryID = item.CountryID, Name = item.Name });
            }
            return lstCountry;
        }
        [HttpGet]
        public Country GetCategoryById(int id)
        {
            var item = db.Countries.SingleOrDefault(n => n.CountryID == id);
            var country = new Country() { CountryID = item.CountryID, Name = item.Name };
            return country;
        }
        [HttpGet]
        [Route("api/CountryApi/Movie")]
        public List<Movie> GetMovieByCountry(int id)
        {
            var movie = db.Movies.Where(n => n.CountryID == id).ToList();
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
        [HttpPost]
        public JsonResult<bool> insert(CountryModel countryModel)
        {
            var country = db.Countries.SingleOrDefault(n => n.CountryID == countryModel.id
            );
            if (country == null)
            {
                Country c = new Country() { CountryID = countryModel.id, Name = countryModel.name, CreatedDate = DateTime.Now, Status = true };
                db.Countries.Add(c);
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }
        [HttpPut]
        public bool update(int id, string name)
        {
            Country country = db.Countries.SingleOrDefault(n => n.CountryID == id);
            if (country == null)
            {
                return false;
            }

            country.CountryID = id;
            country.Name = name;
            db.SaveChanges();
            return true;
        }
        [HttpDelete]
        public bool delete(int id)
        {
            var country = db.Countries.SingleOrDefault(n => n.CountryID == id);
            if (country == null)
            {
                return false;
            }
            var m = db.Movies.Where(n => n.CountryID == id).ToList();
            if (m.Count == 0)
            {
                db.Countries.Remove(country);
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
