using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Fluent.Infrastructure.FluentModel;

namespace Web.App_Start
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.UseFacebookAuthentication(
                appId: "2412150348926508",
                appSecret : "43b846231522e6e40fc67666921efb85"
                ) ;
        }
    }
}