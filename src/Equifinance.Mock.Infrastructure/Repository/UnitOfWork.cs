using Equifinance.Mock.API.Repository;
using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Infrastructure.Data;

namespace Equifinance.Mock.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Problem = new ProblemRepository(_context);
            TestCase = new TestCaseRepository(_context);
            TestResult = new TestResultRepository(_context);
            User = new UserRepository(_context);
            Submission = new SubmissionRepository(_context);
        }

        public IProblemRepository Problem { get; private set; }
        public ITestCaseRepository TestCase { get; private set; }
        public ITestResultRepository TestResult { get; private set; }
        public IUserRepository User { get; private set; }
        public ISubmissionRepository Submission { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
