using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FBARefund.Startup))]
namespace FBARefund
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
