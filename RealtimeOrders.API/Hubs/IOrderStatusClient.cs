using RealtimeOrders.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeOrders.API.Hubs
{
    public interface IOrderStatusClient
    {
        Task NewOrderPlaced(Order order);
    }
}
