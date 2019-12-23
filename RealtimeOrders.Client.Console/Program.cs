using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;


namespace RealtimeOrders.Client.Console
{
    class Program
    {
        static async Task Main()
        {
            System.Console.WriteLine("Orders console client started..");
            var connection = new HubConnectionBuilder()
                .WithUrl(new Uri("http://localhost:61663"))
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                })
                .WithAutomaticReconnect()
                .Build();

            System.Console.WriteLine("Starting connection to check for any new orders. Press Ctrl-C to close.");
            
            connection.On<Order>("broadcastorderstatus", (order) =>
               System.Console.WriteLine($"Somebody ordered an {order.ItemName}"));




            await connection.StartAsync();
        }
    }
}
