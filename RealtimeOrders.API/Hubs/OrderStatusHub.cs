using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace RealtimeOrders.API.Hubs
{
    public class OrderStatusHub : Hub
    {
        public async Task BroadcastOrderStatus()
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastorderstatus", "Order 1", "In Process");
        }
    }
}
