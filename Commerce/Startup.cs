using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Commerce.Startup))]
namespace Commerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
