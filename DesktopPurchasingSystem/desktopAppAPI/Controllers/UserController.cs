using DesktopAppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesktopAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(desktopAppDbContext context) : ControllerBase
    {
        private readonly desktopAppDbContext _db = context;

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        // GET: api/User
        [HttpGet("getPieces")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetPieces()
        {
            return await _db.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(Guid id)
        {
            var user = await _db.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserModel>> CreateUser(UserModel user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
        }

        [HttpPost("UpdateUser")]
        public async Task<ActionResult<UserModel>> UpdateUser(UserModel user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(Guid id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
