using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalrMessenger
{
    [HubName("stockTickerHub")] //override name for testing, otherwise it should be camelCase name of class: signalrHub in javascript
    public class SignalrHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.updateSyncStatus(message);  //name of client method to call
        }
    }
}