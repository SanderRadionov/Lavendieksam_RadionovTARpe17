using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lavendieksam_RadionovTARpe17.Startup))]
namespace Lavendieksam_RadionovTARpe17
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
