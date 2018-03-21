using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KeepAlive.Startup))]
namespace KeepAlive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
