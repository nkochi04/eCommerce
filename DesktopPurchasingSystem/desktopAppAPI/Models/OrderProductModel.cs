namespace DesktopAppAPI.Models
{
    public class OrderProductModel
    {
        public Guid Id { get; set; }
        public Guid Order_ID { get; set; }
        public Guid Product_ID { get; set; }
    }
}
