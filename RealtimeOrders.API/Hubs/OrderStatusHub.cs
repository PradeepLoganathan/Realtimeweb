using Microsoft.AspNetCore.SignalR;
using RealtimeOrders.API.Models;
using System.Threading.Tasks;

namespace RealtimeOrders.API.Hubs
{
    public class OrderStatusHub : Hub<IOrderStatusClient>
    {
        public async Task PlaceNewOrder(Order order)
        {
            // Call the newOrderPlaced method to update all clients.
            await Clients.All.NewOrderPlaced(order);
        }
    }
}
