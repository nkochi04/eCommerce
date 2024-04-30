namespace Playground.Models
{
    public class AddressModel
    {
        public Guid ID { get; set; }
        public int Number { get; set; }
        public string Road { get; set; } = string.Empty;
        public string Postalcode { get; set; } = string.Empty;
    }
}
