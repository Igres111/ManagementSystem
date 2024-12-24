using ManagmentSystemApi.Data;
using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;
using ManagmentSystemApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sprache;
using System.Security;

namespace ManagmentSystemApi.Repositories
{
    public class IUserRepository : IUser
    {
        public readonly Context _context;
        public readonly TokenGenerator _tokenGenerator;
        public IUserRepository(Context context, TokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }
        public async Task RegisterUser(RegisterUserDto user)
        {
            var exist = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (exist != null)
            {
              throw new Exception("User already exists");
            }
            User newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Age = user.Age,
                Role = user.Role,
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }
        public async Task<(string AccessToken, string RefreshToken)> LoginUser(LoginUserDto user)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email );
           
            if(foundUser != null && BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password))
            {
                var accessToken = _tokenGenerator.CreateAccessToken(foundUser); 
                var refreshToken = await _tokenGenerator.CreateRefreshTokenAsync(foundUser);
                return (accessToken,refreshToken.Token);
            }
             throw new Exception("Invalid credentials");
        }
        public async Task<string> RefreshAccessToken(string tokenString)
        {
        return await _tokenGenerator.RefreshAccessTokenAsync(tokenString);
        }
    }
}
