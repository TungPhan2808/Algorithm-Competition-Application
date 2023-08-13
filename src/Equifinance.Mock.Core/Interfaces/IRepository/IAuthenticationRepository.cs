using Equifinance.Mock.Core.Models;

namespace Equifinance.Mock.Core.Interfaces.IRepository
{
    public interface IAuthenticationRepository
    {
        Task<bool> IsEmailExistsAsync(string email);
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
    }
}
