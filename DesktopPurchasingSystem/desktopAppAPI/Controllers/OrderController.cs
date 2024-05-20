using DesktopAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesktopAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(desktopAppDbContext context) : ControllerBase
    {
        private readonly desktopAppDbContext _db = context;

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_db.Orders.ToList());
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();

            return Ok();
        }
    }
}
