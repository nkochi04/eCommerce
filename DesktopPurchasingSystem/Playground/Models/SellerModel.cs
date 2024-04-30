namespace Playground.Models
{
    public class SellerModel
    {
        public Guid ID { get; set; }
        public Guid Adress_ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
