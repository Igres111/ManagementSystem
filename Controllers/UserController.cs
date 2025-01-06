using Azure.Core;
using ManagmentSystemApi.Data;
using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;
using ManagmentSystemApi.Repositories;
using ManagmentSystemApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ManagmentSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly Context _context;
        public readonly TokenGenerator _token;
        public readonly IUser _methods;
        public UserController(Context context, TokenGenerator token, IUser methods)
        {
            _context = context;
            _token = token;
            _methods = methods;
        }

        [HttpGet("GetUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUser()
        {
            var result = await _context.Users.Select(u => new UserInfoDto
            {
                Email = u.Email,
                Name = u.Name,
                LastName = u.LastName,
                Age = u.Age,
                Id = u.Id
            }).ToListAsync();

            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _methods.RegisterUser(user);
            return Ok("Registered Succesfully");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _methods.LoginUser(user);
            return Ok(new { result.AccessToken, result.RefreshToken });
        }
        [HttpPost("Refresh-Token")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var newAccessToken = await _methods.RefreshAccessToken(refreshToken);
            return Ok(newAccessToken);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(result != null)
            {
                _context.Users.Remove(result);
                await _context.SaveChangesAsync();
                return Ok("User deleted");
            }
            return NotFound("User not found");
        }
    }
}