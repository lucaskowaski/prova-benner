using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Microondas.Hubs.Startup))]
namespace Microondas.Hubs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}