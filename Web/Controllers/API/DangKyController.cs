using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Models;

namespace Web.Controllers.API
{
    public class DangKyController : ApiController
    {
        Movie12Entities db = new Movie12Entities();
        [HttpGet]
        public int CountDangKy()
        {
            var price = db.Users.Where(n => n.IDPay != null).ToList();
            return price.Count();
        }
    }
}
