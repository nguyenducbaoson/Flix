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
                appId: "674102500308122",
                appSecret : "81870c5763cde2c23a5b9b1f6378a53f"
                ) ;
        }
    }
}