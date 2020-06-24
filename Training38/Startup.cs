using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Training38.Startup))]
namespace Training38
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
