using ManagmentSystemApi.Data;
using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagmentSystemApi.Repositories
{
    public class IUserRepository : IUser
    {
        public readonly Context _context;
        public IUserRepository(Context context)
        {
            _context = context;
        }
        public async Task AddUser(RegisterUserDto user)
        {

            User newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Age = user.Age,
                Role = user.Role,
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

    }
}
