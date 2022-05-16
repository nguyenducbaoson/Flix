using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Web.Models;

namespace Web.Controllers
{
    public class CategoryApiController : ApiController
    {
        Movie12Entities db = new Movie12Entities();
        [HttpGet]
        public List<Category> GetCategory()
        {
            var lstCategory = new List<Category>();
            foreach (var item in db.Categories.ToList())
            {
                lstCategory.Add(new Category() { CategoryID = item.CategoryID, NameCategory = item.NameCategory });
            }
            return lstCategory;
        }
        [HttpGet]
        public Category GetCategoryById(int id)
        {
            var item = db.Categories.SingleOrDefault(n => n.CategoryID == id);
            var category = new Category() { CategoryID = item.CategoryID, NameCategory = item.NameCategory };
            return category;
        }

        [HttpGet]
        [Route("api/CategoryApi/Movie")]
        public List<Movie> GetMovieByCategory(int id)
        {
            var movie = db.Movies.Where(n => n.CategoryID == id).ToList();
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
        public JsonResult<bool> insert(CategoryModel categoryModel)
        {
            Category category = db.Categories.SingleOrDefault(n => n.CategoryID == categoryModel.id);
            if (category == null)
            {
                Category c = new Category() { CategoryID = categoryModel.id, NameCategory = categoryModel.name, CreatedDate = DateTime.Now, Status = true };
                db.Categories.Add(c);
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }
        [HttpPut]
        public bool update(int id, string name)
        {
            Category category = db.Categories.SingleOrDefault(n => n.CategoryID == id);
            if (category == null)
            {
                return false;
            }

            category.CategoryID = id;
            category.NameCategory = name;
            db.SaveChanges();
            return true;
        }
        [HttpDelete]
        public bool delete(int id)
        {
            Category category = db.Categories.SingleOrDefault(n => n.CategoryID == id);
            if (category == null)
            {
                return false;
            }
            var m = db.Movies.Where(n => n.CategoryID == id).ToList();
            //if (m.Count == 0)
            //{
            //    db.Categories.Remove(category);
            //    db.SaveChanges();
            //    return true;
            //}
            return false;

        }
    }
}
