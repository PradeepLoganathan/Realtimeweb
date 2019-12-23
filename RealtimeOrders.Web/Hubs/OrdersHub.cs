using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace RealtimeOrders.Web.Hubs
{
    public class OrdersHub : Hub
    {
        public async Task Send(string name, string message)
        {
            
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}
