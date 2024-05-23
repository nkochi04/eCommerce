namespace DesktopAppAPI.DTO
{
    public class ProductDto
    {
        public Guid ID { get; set; }
        public Guid Seller_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; } = 0;
        public byte[]? ImageData { get; set; } = null;

        public List<PieceDto> Pieces { get; set; } = [];
    }
}
