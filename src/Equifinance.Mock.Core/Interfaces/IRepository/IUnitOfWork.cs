namespace Equifinance.Mock.Core.Interfaces.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IProblemRepository Problem { get; }
        ITestCaseRepository TestCase { get; }
        ITestResultRepository TestResult { get; }
        IUserRepository User { get; }
        ISubmissionRepository Submission { get; }
        int Save();
    }
}
