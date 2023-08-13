using Equifinance.Mock.Core.DTO.Result;

namespace Equifinance.Mock.Core.Interfaces.IFactory
{
    public interface IExecetuonFactory
    {
        Task<ExecutionResult> Execution(string language, string code, List<string> input);
    }
}
