using DotNetEnv;
using ManagmentSystemApi.Data;
using ManagmentSystemApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagmentSystemApi.Services
{
    public class TokenGenerator
    {
        public readonly Context _context;
        public readonly IConfiguration _configuration;
        public TokenGenerator(Context context, IConfiguration configuration)
        {
            _context= context;
            _configuration = configuration;
        }
        public string AccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = Environment.GetEnvironmentVariable("Key");

            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new Exception("Restricted");
            }
            var key = Encoding.UTF8.GetBytes(jwtKey);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, user.Name), 
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(ClaimTypes.Role, "User")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
