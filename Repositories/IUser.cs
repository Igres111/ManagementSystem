using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;

namespace ManagmentSystemApi.Repositories
{
    public interface IUser
    {
       Task AddUser(RegisterUserDto user);
    }
}
