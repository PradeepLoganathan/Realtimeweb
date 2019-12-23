using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeOrders.API.Models
{
    public class Order
    {
        public string OrderID { get; set;}
        public string ItemName { get; set;}
        public int Quantity { get; set;}
    }
}
