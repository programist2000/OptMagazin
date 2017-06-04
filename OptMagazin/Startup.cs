using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OptMagazin.Startup))]
namespace OptMagazin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
