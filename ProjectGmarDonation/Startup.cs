using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectGmarDonation.Startup))]
namespace ProjectGmarDonation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
