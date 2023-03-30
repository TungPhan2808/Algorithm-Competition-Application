using Equifinance.Mock.API.Data;
using Equifinance.Mock.API.Interfaces;
using Equifinance.Mock.API.Models;
using Equifinance.Mock.Infrastructure.Repository;

namespace Equifinance.Mock.API.Repository
{
    public class ProblemRepository : Repository<Problem>, IProblemRepository
    {
        public ProblemRepository(DataContext context) : base(context)
        {
        }
    }
}
