using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GRB.Startup))]
namespace GRB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
