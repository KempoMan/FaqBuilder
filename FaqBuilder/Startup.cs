using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FaqBuilder.Startup))]
namespace FaqBuilder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
