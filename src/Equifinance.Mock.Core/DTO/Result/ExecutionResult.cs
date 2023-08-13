namespace Equifinance.Mock.Core.DTO.Result
{
    public class ExecutionResult
    {
        public string Output { get; set; }
        public string ErrorMessage { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public long MemoryUsage { get; set; }
    }
}
