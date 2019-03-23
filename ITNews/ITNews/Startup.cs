using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITNews.Startup))]
namespace ITNews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
