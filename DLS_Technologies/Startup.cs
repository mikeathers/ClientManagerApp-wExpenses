using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DLS_Technologies.Startup))]
namespace DLS_Technologies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
