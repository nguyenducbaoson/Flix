using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Web.StartupOwin))]

namespace Web
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
