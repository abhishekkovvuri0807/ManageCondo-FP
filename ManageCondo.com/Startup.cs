using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageCondo.com.Startup))]
namespace ManageCondo.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
