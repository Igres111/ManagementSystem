using Azure.Core;
using ManagmentSystemApi.Data;
using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;
using ManagmentSystemApi.Repositories;
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
        public readonly IUser _methods;
        public UserController(Context context, TokenGenerator token, IUser methods)
        {
            _context = context;
            _token = token;
            _methods = methods;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUser()
        {
            var result = await _context.Users.ToListAsync();
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
    }
}