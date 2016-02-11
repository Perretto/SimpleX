using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simplex.Pizzaria.Startup))]
namespace Simplex.Pizzaria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
