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
    public class TVSeriesController : ApiController
    {
        Movie12Entities db = new Movie12Entities();
        [HttpGet]
        public List<PhimBo> GetAll()
        {
            var movie = db.PhimBoes.ToList();
            var lstMovie = new List<PhimBo>();
            foreach (var item in movie)
            {
                lstMovie.Add(new PhimBo()
                {
                    Name = item.Name,
                    IDCategory = item.IDCategory,
                    Year = item.Year,
                    Images = item.Images,
                    Viewed = item.Viewed,
                    Descripton = item.Descripton,
                });
            }
            return lstMovie;
        }
    }
}
