namespace Equifinance.Mock.Core.Models
{
    public class TestCase
    {
        public int TestCaseID { get; set; }
        public string? Input { get; set; }
        public string? ExpectedOutput { get; set; }
        public int TimeLimit { get; set; }
        public int MemoryLimit { get; set; }
        public int ProblemID { get; set; }
        public Problem? Problem { get; set; }
        public ICollection<TestResult>? TestResults { get; set; }
    }
}
