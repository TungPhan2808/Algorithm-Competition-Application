using Equifinance.Mock.API.DTO;
using Equifinance.Mock.Core.DTO.Request;

namespace Equifinance.Mock.Core.Interfaces.IService
{
    public interface IProblemService
    {
        Task<ProblemDto> CreateProblemAsync(int userId, ProblemRequest problemCreate);
        Task<ProblemDto> GetProblemByIdAsync(int problemId);
        Task<IEnumerable<ProblemDto>> GetAllUserProblemAsync();
        Task UpdateProblemAsync(int problemId, ProblemRequest problemUpdate);
        Task DeleteProblemAsync(int problemId);
    }
}
