using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShop_Mobile.Startup))]
namespace WebShop_Mobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
