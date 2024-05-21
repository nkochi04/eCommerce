using DesktopAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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
            ProductDTO[] products = [.. _db.Products
                .Include(p => p.Pieces)
                .Select(p => new ProductDTO
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    ImageData = p.ImageData,
                    Seller_Id = p.Seller_ID
                    
                })];

            PieceDTO[] pieces = [.. _db.Pieces
                .Select(p => new PieceDTO{
                    Serial_Number = p.Serial_Number,
                    Sold = p.Sold,
                    OrderId = p.OrderId,
                    ProductId = p.ProductId,
            })];

            foreach (var product in products)
            {
                product.Pieces.AddRange(pieces.Where(x => x.ProductId == product.ID).ToList());
            }

            return products;
        }
    }

    public class ProductDTO
    {
        public Guid ID { get; set; }
        public Guid Seller_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public byte[]? ImageData { get; set; } = null;

        public List<PieceDTO> Pieces { get; set; } = [];
    }

    public class PieceDTO
    {
        public int Serial_Number { get; set; }
        public bool Sold { get; set; }

        public Guid? OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
