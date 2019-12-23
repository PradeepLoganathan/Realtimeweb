using System;

namespace RealtimeOrders.Helper
{
   
    public class OrderSimulator
    {
        private readonly Random random;
        private readonly string[] OrderStatus =
        {
            "Accepted", 
            "Payment Complete", 
            "Shipped", 
            "In Transit", 
            "Delivered"
        };


        public OrderSimulator(Random random)
        {

        }

        public void GetOrderStatus(int orderNo)
        {
            
        }

    }
}
