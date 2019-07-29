using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArvutikomplektUL.Startup))]
namespace ArvutikomplektUL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
