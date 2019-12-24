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

            //create the connection to the order status hub
            var connection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:5001/orderstatushub"))
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                })
                .WithAutomaticReconnect()
                .Build();

            connection.Reconnecting += error =>
            {
                System.Console.WriteLine("console is reconnecting to hub");
                return Task.CompletedTask;
            };

            connection.Reconnected += connectionId =>
            {
                System.Console.WriteLine($"console reconnected to hub with connection ID {connectionId}");
                return Task.CompletedTask;
            };


            System.Console.WriteLine("Starting connection to check for any new orders. Press Ctrl-C to close.");
            
            //handle the newOrderPlaced event from the server
            connection.On<Order>("NewOrderPlaced", (order) =>
               System.Console.WriteLine($"Somebody ordered an {order.ItemName}"));

            
            await connection.StartAsync();

            ConsoleKeyInfo keyinfo;
            do
            {
                System.Console.WriteLine("Press F12 to order a new item or X to exit...");
                keyinfo = System.Console.ReadKey();
                
                if( keyinfo.Key == ConsoleKey.F12)
                    await connection.InvokeAsync("PlaceNewOrder", new Order() { ItemName = "Cliensidehub order", OrderID = "JHGJHG232", Quantity = 1 });

            }
            while (keyinfo.Key != ConsoleKey.X);
        }

     
    }
}
