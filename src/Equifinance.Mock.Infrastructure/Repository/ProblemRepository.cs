using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Models;
using Equifinance.Mock.Infrastructure.Data;
using Equifinance.Mock.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Equifinance.Mock.API.Repository
{
    public class ProblemRepository : GenericRepository<Problem, int>, IProblemRepository
    {
        public ProblemRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> IsExistedUser(int userId)
        {
            return await _context.Problems.AnyAsync(p => p.UserID == userId);
        }
    }
}
