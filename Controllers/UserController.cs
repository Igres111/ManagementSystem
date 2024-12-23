using Azure.Core;
using ManagmentSystemApi.Data;
using ManagmentSystemApi.Dtos;
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
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (exist != null)
            {
                return BadRequest("User already exist");
            }
            User newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Age = user.Age,
                Role = user.Role,
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return Ok("Registered Succesfully");
        }
        }
}
