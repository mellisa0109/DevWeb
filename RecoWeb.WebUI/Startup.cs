using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecoWeb.WebUI.Startup))]
namespace RecoWeb.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
