using Equifinance.Mock.Core.Models;

namespace Equifinance.Mock.Core.Interfaces.IRepository
{
    public interface IProblemRepository : IGenericRepository<Problem, int>
    {
        Task<bool> IsExistedUser(int userId);
    }
}
