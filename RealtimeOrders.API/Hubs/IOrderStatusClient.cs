using RealtimeOrders.API.Models;
using System.Threading.Tasks;

namespace RealtimeOrders.API.Hubs
{
    public interface IOrderStatusClient
    {
        Task NewOrderPlaced(Order order);
    }
}
