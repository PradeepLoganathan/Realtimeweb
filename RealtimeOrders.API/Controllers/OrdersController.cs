using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealtimeOrders.API.Hubs;
using RealtimeOrders.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealtimeOrders.API.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IHubContext<OrderStatusHub> orderStatusHub;

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return new Order[] { new Order { OrderID = "ASADS00923", ItemName = "Google mini", Quantity = 1}, new Order { OrderID = "KGKHKH908", ItemName = "NEST doorbella", Quantity = 1 } };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return new Order { OrderID = "ASADS00923", ItemName = "Google mini", Quantity = 1 };
        }

        // POST api/<controller>
        [HttpPost]
        public async Task PostAsync([FromBody]Order order)
        {
            await orderStatusHub.Clients.All.SendAsync("NewOrder", new object[] { order});
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
