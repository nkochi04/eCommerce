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
        public IEnumerable<ProductDTO> GetProducts()
        {
            return [.. _db.Products
                .Include(p => p.Pieces)
                .Select(p => new ProductDTO
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    ImageData = p.ImageData
                    //Todo: Add Pieces
                })];
        }
    }

    public class ProductDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public byte[]? ImageData { get; set; } = null;

    }
}
