using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassicWeb.Startup))]
namespace ClassicWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
