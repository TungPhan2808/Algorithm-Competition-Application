using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Models;
using Equifinance.Mock.Infrastructure.Data;
using Equifinance.Mock.Infrastructure.Repository;

namespace Equifinance.Mock.API.Repository
{
    public class ProblemRepository : GenericRepository<Problem>, IProblemRepository
    {
        public ProblemRepository(DataContext context) : base(context)
        {
        }

        public bool IsExistedUser(int userId)
        {
            var exist = _context.Problems.Where(x => x.UserID == userId).Any();
            return exist;
        }
    }
}
