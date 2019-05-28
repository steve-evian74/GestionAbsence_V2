using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionAbsence.Startup))]
namespace GestionAbsence
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
