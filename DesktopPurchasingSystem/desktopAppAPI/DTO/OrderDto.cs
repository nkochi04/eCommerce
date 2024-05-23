namespace DesktopAppAPI.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public Guid User_ID { get; set; }

        public Guid Supplier_ID { get; set; }

        public required List<ProductDto> Products { get; set; }
    }
}
