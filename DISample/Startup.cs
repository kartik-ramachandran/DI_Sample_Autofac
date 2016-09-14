using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DISample.Startup))]
namespace DISample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
