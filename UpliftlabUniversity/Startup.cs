using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UpliftlabUniversity.Startup))]
namespace UpliftlabUniversity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
