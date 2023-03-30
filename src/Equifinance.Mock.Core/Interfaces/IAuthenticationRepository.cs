using Equifinance.Mock.API.Models;

namespace Equifinance.Mock.API.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<bool> EmailExistsAsync(string email);
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
    }
}
