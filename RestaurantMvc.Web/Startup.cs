using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantMvc.Web.Startup))]
namespace RestaurantMvc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
