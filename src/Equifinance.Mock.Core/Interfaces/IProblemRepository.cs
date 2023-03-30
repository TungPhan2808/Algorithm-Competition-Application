using Equifinance.Mock.API.Models;
using Equifinance.Mock.Core.Interfaces;

namespace Equifinance.Mock.API.Interfaces
{
    public interface IProblemRepository : IRepository<Problem>
    {
        Task InsertAsync(Problem problem);
        Task<Problem?> GetByIdAsync(int problemId);
        Task<IEnumerable<Problem>> GetAllAsync();
        Task UpdateAsync(Problem problem);
        Task DeleteAsync(int problemId);
    }
}
