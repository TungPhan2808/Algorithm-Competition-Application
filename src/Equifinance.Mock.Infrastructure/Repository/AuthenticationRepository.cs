using Equifinance.Mock.Core.Exceptions;
using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Models;
using Equifinance.Mock.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Equifinance.Mock.API.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DataContext _context;

        public AuthenticationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new EntityNotFoundException($"No user found with email {email}");
            }
            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == id);
            if (user == null)
            {
                throw new EntityNotFoundException($"No user found with id {id}");
            }
            return user;
        }
    }
}
