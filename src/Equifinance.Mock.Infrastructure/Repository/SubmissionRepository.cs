using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Models;
using Equifinance.Mock.Infrastructure.Data;

namespace Equifinance.Mock.Infrastructure.Repository
{
    public class SubmissionRepository : GenericRepository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(DataContext context) : base(context)
        {
        }
    }
}
