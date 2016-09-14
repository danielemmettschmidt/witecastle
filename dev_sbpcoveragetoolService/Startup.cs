using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(dev_sbpcoveragetoolService.Startup))]

namespace dev_sbpcoveragetoolService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}