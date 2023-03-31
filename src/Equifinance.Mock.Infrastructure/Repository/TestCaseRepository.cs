using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Models;
using Equifinance.Mock.Infrastructure.Data;

namespace Equifinance.Mock.Infrastructure.Repository
{
    public class TestCaseRepository : GenericRepository<TestCase, int>, ITestCaseRepository
    {
        public TestCaseRepository(DataContext context) : base(context)
        {
        }
    }
}
