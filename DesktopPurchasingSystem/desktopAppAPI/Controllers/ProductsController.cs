using DesktopAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesktopAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(desktopAppDbContext db) : ControllerBase
    {
        private readonly desktopAppDbContext _db = db;

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _db.Products.Include(p => p.Pieces);
        }
        //TODO: DTO's
    }
}
