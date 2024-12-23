using ManagmentSystemApi.Data;
using ManagmentSystemApi.Models;
using ManagmentSystemApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagmentSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly Context _context;
        public readonly TokenGenerator _token;
        public UserController(Context context, TokenGenerator token)
        {
            _context = context;
            _token = token;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUser()
        {
            var result = await _context.Users.ToListAsync();
            return Ok(result);
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> PostUser(User user)
        {
         var token =  _token.AccessToken(user);
            return Ok(token);
        }
    }
}
