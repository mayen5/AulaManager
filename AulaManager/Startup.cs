using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AulaManager.Startup))]
namespace AulaManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
