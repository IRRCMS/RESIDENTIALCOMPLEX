using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IRRCMS.Startup))]
namespace IRRCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
