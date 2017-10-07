using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(xssiServer.Startup))]
namespace xssiServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
