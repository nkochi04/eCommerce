using DesktopAppAPI.DTO;
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
        public IEnumerable<ProductDto> GetProducts()
        {
            ProductDto[] products = [.. _db.Products
                .Select(p => new ProductDto
                {
                    Id = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    ImageData = p.ImageData,
                    Seller_Id = p.Seller_ID
                })];

            PieceDto[] pieces = [.. _db.Pieces
                .Select(p => new PieceDto{
                    Serial_Number = p.Serial_Number,
                    Sold = p.Sold,
                    OrderId = p.OrderId,
                    ProductId = p.ProductId,
                })];

            //foreach (var product in products)
            //{
            //    product.Pieces.AddRange(pieces.Where(x => x.ProductId == product.Id).ToList());
            //}

            return products;
        }
    }
}
