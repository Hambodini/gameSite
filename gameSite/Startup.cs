using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gameSite.Startup))]
namespace gameSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
