using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class SellerModel
    {
        [Key]
        public Guid ID { get; set; }
        public Guid Adress_ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
