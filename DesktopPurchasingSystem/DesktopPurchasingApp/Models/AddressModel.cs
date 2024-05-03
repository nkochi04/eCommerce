using System.ComponentModel.DataAnnotations;

namespace DesktopPurchasingApp.Models
{
    public class AddressModel
    {
        [Key]
        public Guid ID { get; set; }
        public int Number { get; set; }
        public string Road { get; set; } = string.Empty;
        public string Postalcode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
