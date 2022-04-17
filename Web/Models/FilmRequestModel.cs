using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FilmRequestModel
    {
        //string id, string name, string image, int category, string time, string linkmovie, string linktrailer, int year, int country, string description
        public string Id { get; set; }
        public string Name { get; set; }
        public string image { get; set; }
        public int category { get; set; }
        public string time { get; set; }
        public string linkmovie { get; set; }
        public string linktrailer { get; set;}
        public int year { get; set; }
        public int country { get; set;}
        public string description { get; set; }

    }
}