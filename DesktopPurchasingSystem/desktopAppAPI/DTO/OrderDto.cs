namespace DesktopAppAPI.DTO
{
    public class OrderDto
    {
        public Guid Id;

        public Guid User_ID;

        public Guid Supplier_ID;

        public required List<ProductDto> Products;
    }
}
