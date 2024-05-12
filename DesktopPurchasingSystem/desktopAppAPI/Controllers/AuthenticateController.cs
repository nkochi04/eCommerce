using DesktopAppAPI.DTO;
using DesktopAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesktopAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly desktopAppDbContext _db;

        public AuthenticateController(desktopAppDbContext context)
        {
            _db = context;
        }

        [HttpPost]
        public ActionResult<User> Login(LoginModel user)
        {
            var userFromDb = _db.Users.Include(u => u.Department).FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (userFromDb == null)
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                Id = userFromDb.ID,
                Username = userFromDb.Username,
                Firstname = userFromDb.Firstname,
                Lastname = userFromDb.Lastname,
                Department_ID = userFromDb.DepartmentId,
                Department = new DepartmentDto
                {
                    Id = userFromDb.Department.ID,
                    Name = userFromDb.Department.Name,
                    Payment_Adress = userFromDb.Department.Payment_Adress
                }
            };

            return Ok(userDto);
        }
    }

    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Guid Department_ID { get; set; }
        public DepartmentDto Department { get; set; }
    }

    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Payment_Adress { get; set; }
    }
}
