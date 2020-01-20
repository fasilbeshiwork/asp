using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cooking.Web.Startup))]
namespace Cooking.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
