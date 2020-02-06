using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSBAdmin.Startup))]
namespace FSBAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
