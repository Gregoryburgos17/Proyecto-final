using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Almacen02.Startup))]
namespace Almacen02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
