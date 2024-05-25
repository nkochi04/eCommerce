namespace DesktopAppAPI.DTO
{
    public class SellerDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid AddressId { get; set; }
    }
}
