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
        public ActionResult<UserDb> Login(LoginDto user)
        {
            var userFromDb = _db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (userFromDb == null)
            {
                return NotFound();
            }

            var department = _db.Departments.FirstOrDefault(d => d.ID == userFromDb.DepartmentId);

            if (department == null)
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
                    Id = department.ID,
                    Name = department.Name,
                    Payment_Adress = department.Payment_Adress
                }
            };

            return Ok(userDto);
        }
    }
}
