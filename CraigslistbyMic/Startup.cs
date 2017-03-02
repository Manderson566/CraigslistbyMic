using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CraigslistbyMic.Startup))]
namespace CraigslistbyMic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
