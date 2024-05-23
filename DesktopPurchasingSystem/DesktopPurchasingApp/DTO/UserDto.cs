namespace DesktopAppAPI.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public Guid Department_ID { get; set; }
        public DepartmentDto? Department { get; set; }
    }
}
