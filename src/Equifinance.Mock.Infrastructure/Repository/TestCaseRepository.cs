using Equifinance.Mock.API.Data;
using Equifinance.Mock.API.Models;

namespace Equifinance.Mock.Infrastructure.Repository
{
    internal class TestCaseRepository : Repository<TestCase>
    {
        public TestCaseRepository(DataContext context) : base(context) { }
    }
}
