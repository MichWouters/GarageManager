using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GarageManager.App_Start.Startup1))]

namespace GarageManager.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}