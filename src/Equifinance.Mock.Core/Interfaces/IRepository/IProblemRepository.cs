using Equifinance.Mock.Core.Models;

namespace Equifinance.Mock.Core.Interfaces.IRepository
{
    public interface IProblemRepository : IGenericRepository<Problem>
    {
        bool IsExistedUser(int userId);
    }
}
