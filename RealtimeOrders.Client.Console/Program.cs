using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace RealtimeOrders.Client.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.Title = "RealtimeOrders.Client.Console";

            //#region configuration
            //IConfiguration Configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddEnvironmentVariables()
            //    .AddCommandLine(args)
            //    .Build();
            //#endregion

            //var path = Environment.GetEnvironmentVariable("huburl");
            //System.Console.WriteLine("Orders console client started..");            
            //create the connection to the order status hub
            //Uri OrderStatusHubPath = new UriBuilder("https", "localhost", 32776, "orderstatushub").Uri;
            //Uri OrderStatusHubPath = new Uri("http://realtimeorders.api/orderstatushub");
            //Uri OrderStatusHubPath = new Uri("http://realtimeorders.api/orderstatushub");
            //Uri OrderStatusHubPath = new Uri("http://realtimeorders.api/orderstatushub");
            Uri OrderStatusHubPath = new Uri("http://localhost:32775/orderstatushub");
            var connection = new HubConnectionBuilder()
                .WithUrl(OrderStatusHubPath)
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
