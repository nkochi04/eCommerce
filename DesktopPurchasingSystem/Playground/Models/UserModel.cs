namespace Playground.Models
{
    public class UserModel
    {
        public Guid ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public Guid Department_ID { get; set; }
    }
}
