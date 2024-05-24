using DesktopAppAPI.DTO;
using DesktopAppAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesktopAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(desktopAppDbContext context) : ControllerBase
    {
        private readonly desktopAppDbContext _db = context;

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_db.Orders.ToList());
        }

        [HttpGet("{userId}")]
        public ActionResult<List<OrderDto>> GetOrders(Guid userId)
        {
            List<OrderDto>? orders = [.. _db.Orders
                .Where(x => x.User_ID == userId)
                .Select(x => new OrderDto()
                {
                    Id = x.ID,
                    User_ID = x.User_ID,
                    Supplier_ID = x.Supplier_ID,
                    Products = new List<ProductDto>()
                })];

            var test = _db.Pieces.ToList();

            foreach (var order in orders)
            {
                List<PieceDto> pieces = [.. _db.Pieces
                .Where(x => x.OrderId == order.Id)
                .Select(x => new PieceDto()
                {
                    Serial_Number = x.Serial_Number,
                    Sold = x.Sold,
                    OrderId = x.OrderId,
                    ProductId = x.ProductId
                })];

                var productsIds = pieces.Select(p => p.ProductId).Distinct().ToList();

                foreach (var productId in productsIds)
                {
                    var product = _db.Products.Where(x => x.ID == productId).Select(x => new ProductDto()
                    {
                        Id = x.ID,
                        Name = x.Name,
                        Price = x.Price,
                        Seller_Id = x.Seller_ID,
                    }).FirstOrDefault();

                    if (product != null)
                    {
                        product.Pieces = pieces.Where(x => x.ProductId == productId).ToList();
                        order.Products.Add(product);
                    }
                }
            }

            return Ok(orders);
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderDto orderDto)
        {
            List<PieceDto> allPieces = orderDto.Products
            .SelectMany(products => products.Pieces)
            .ToList();

            foreach (PieceDto piece in allPieces)
            {
                var pieceDb = _db.Pieces.Where(x => x.Serial_Number == piece.Serial_Number).SingleOrDefault();
                if (pieceDb == null)
                {
                    return NotFound("piece not found");
                }
                pieceDb.Sold = true;
                pieceDb.OrderId = orderDto.Id;
                pieceDb.ProductId = piece.ProductId;
                _db.Pieces.Update(pieceDb);
            }

            _db.Orders.Add(new OrderDb()
            {
                User_ID = orderDto.User_ID,
                Supplier_ID = _db.Suppliers.FirstOrDefault().ID, // TODO: let user choose
                ID = orderDto.Id
            });

            _db.SaveChanges();
            return Ok();
        }
    }
}
