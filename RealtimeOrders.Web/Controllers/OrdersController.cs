using Microsoft.AspNetCore.Mvc;
using RealtimeOrders.Web.Models;
using System.Threading.Tasks;

namespace RealtimeOrders.Web.Controllers
{
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        public OrdersController()
        {

        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        public async Task<IActionResult> PlaceOrder([FromBody]Order order)
        {

            return Accepted();
        }
    }
}