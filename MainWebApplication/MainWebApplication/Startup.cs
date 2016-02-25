using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MainWebApplication.Startup))]
namespace MainWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
