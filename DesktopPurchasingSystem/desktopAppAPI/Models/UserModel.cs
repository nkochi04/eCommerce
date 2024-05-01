using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class UserModel
    {
        [Key]
        public Guid ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public Guid Department_ID { get; set; }
    }
}
