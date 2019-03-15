using Microsoft.AspNet.SignalR;

namespace Microondas.Hubs
{
    public class ProgressHub : Hub
    {
        public static void SendMessage(int tempo, string alimento)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
            hubContext.Clients.All.sendMessage(tempo, alimento);
        }
    }
}