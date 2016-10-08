using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessSite.Startup))]
namespace BusinessSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
