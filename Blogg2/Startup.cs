using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blogg2.Startup))]
namespace Blogg2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
