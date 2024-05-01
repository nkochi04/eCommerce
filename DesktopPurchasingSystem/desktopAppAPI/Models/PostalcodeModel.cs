using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class PostalcodeModel
    {
        [Key]
        public Guid ID { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
