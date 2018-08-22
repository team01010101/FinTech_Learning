using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinTechWebApp.Startup))]
namespace FinTechWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
