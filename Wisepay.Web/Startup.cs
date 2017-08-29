using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wisepay.Web.Startup))]
namespace Wisepay.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
