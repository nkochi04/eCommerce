using DesktopAppAPI.DTO;
using DesktopAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<UserModel> Login(LoginModel user)
        {
            var userFromDb = _db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return userFromDb;
        }
    }
}
