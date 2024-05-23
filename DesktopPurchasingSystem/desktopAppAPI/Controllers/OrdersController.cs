using DesktopAppAPI.DTO;
using DesktopAppAPI.Models;
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
        public ActionResult CreateOrder(OrderDto orderDto)
        {
            List<PieceDto> allPieces = orderDto.Products
            .SelectMany(products => products.Pieces)
            .ToList();

            foreach (PieceDto piece in allPieces)
            {
                _db.Pieces.Update(new PieceDb()
                {
                    Serial_Number = piece.Serial_Number,
                    Sold = true,
                    OrderId = orderDto.Id,
                    ProductId = piece.ProductId
                });
            }

            _db.Orders.Add(new OrderDb()
            {
                User_ID = orderDto.User_ID,
                Supplier_ID = _db.Suppliers.FirstOrDefault().ID,
                ID = Guid.NewGuid()
            });

            _db.SaveChanges();
            return Ok();
        }
    }
}
