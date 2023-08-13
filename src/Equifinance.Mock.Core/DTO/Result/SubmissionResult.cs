using Equifinance.Mock.Core.Models;

namespace Equifinance.Mock.Core.DTO.Result
{
    public class SubmissionResult
    {
        public bool Success { get; set; }
        public int ExecutionTime { get; set; }
        public int MemoryUsage { get; set; }
        public List<TestResult> TestResults { get; set; }
    }
}
