using System;
using System.Collections.Generic;
using System.Text;

namespace RealtimeOrders.Client.Console
{
    public class Order
    {
        public string OrderID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }
}
