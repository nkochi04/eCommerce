using DesktopAppAPI.Controllers;

namespace DesktopAppAPI.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid Seller_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public byte[]? ImageData { get; set; } = null;

        public List<PieceDto> Pieces { get; set; } = [];
    }
}
