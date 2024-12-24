using ManagmentSystemApi.Models;
using System.Text.Json.Serialization;

namespace ManagmentSystemApi.Services
{
    public class RefreshToken
    {
       public Guid Id { get; set; }
       public string Token { get; set; } = string.Empty;
       public DateTime ExpirationDate { get; set; }
       [JsonIgnore]
       public User User { get; set; } 
       public Guid UserId { get; set; }
    }
}
