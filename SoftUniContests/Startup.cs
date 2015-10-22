using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoftUniContests.Startup))]
namespace SoftUniContests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
