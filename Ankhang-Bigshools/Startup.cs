using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ankhang_Bigshools.Startup))]
namespace Ankhang_Bigshools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
