using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SignalrMessenger.Startup))]
namespace SignalrMessenger
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            //app.Map("/signalr", map =>
            //{
            //    HubConfiguration hcf = new HubConfiguration();
            //    map.RunSignalR();
            //});
        }
    }
}