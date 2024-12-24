using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;
using ManagmentSystemApi.Services;

namespace ManagmentSystemApi.Repositories
{
    public interface IUser
    {
       Task RegisterUser(RegisterUserDto user);
       Task<(string AccessToken, string RefreshToken)> LoginUser(LoginUserDto user);
       Task<string> RefreshAccessToken(string token);
    }
}
