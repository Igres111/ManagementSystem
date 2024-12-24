using ManagmentSystemApi.Services;
using System.ComponentModel.DataAnnotations;

namespace ManagmentSystemApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
