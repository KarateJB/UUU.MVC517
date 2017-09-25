using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc517.OwinWebsite.Startup))]
namespace Mvc517.OwinWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
