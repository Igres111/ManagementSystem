using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;

namespace ManagmentSystemApi.Repositories
{
    public interface IUser
    {
       Task RegisterUser(RegisterUserDto user);
       Task<(string AccessToken, string RefreshToken)> LoginUser(LoginUserDto user);
    }
}
