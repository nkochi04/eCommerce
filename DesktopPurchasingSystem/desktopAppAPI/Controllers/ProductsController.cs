using DesktopAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesktopAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(desktopAppDbContext db) : ControllerBase
    {
        private readonly desktopAppDbContext _db = db;

        [HttpGet]
        public IActionResult GetProducts()
        {
            return  Ok(_db.Products.ToList());
        }
    }
}
