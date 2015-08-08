using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OTMST.Startup))]
namespace OTMST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
