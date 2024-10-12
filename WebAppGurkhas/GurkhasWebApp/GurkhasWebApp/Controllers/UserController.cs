using DBController.Models;
using DBController;
using Microsoft.AspNetCore.Mvc;

namespace GurkhasWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DBControllerCtx _context;

        public UserController(DBControllerCtx context)
        {
            _context = context;
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginModel login)
        //{
        //    // Implementar lógica de login
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return user;
        //}
    }

}
