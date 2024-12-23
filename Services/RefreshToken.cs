using ManagmentSystemApi.Models;

namespace ManagmentSystemApi.Services
{
    public class RefreshToken
    {
       public Guid Id { get; set; }
       public string Token { get; set; }
       public DateTime ExpirationDate { get; set; }
       public User User { get; set; }
       public Guid UserId { get; set; }
    }
}
