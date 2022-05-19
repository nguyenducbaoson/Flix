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
                    ID = item.ID,
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
        [HttpPost]
        public JsonResult<bool> insertepisode(TvSeries tvSeries, TVSeries2 tVSeries2)
        {

            var item = db.CTTapPhims.SingleOrDefault(n => n.ID == tvSeries.ID && n.ID2 == tVSeries2.ID);
            if (item == null)
            {
                CTTapPhim u = new CTTapPhim() { ID = tvSeries.ID, TapPhim = tvSeries.TapPhim, Name = tvSeries.Name, Link = tvSeries.Link,ID2=tVSeries2.ID};
                db.CTTapPhims.Add(u);
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }
    }
}
