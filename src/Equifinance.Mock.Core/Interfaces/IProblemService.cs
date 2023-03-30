using Equifinance.Mock.API.DTO;

namespace Equifinance.Mock.API.Interfaces
{
    public interface IProblemService
    {
        Task<ProblemDto> CreateProblemAsync(int userId, ProblemRequestDto problemCreateDto);
        Task<ProblemDto> GetProblemByIdAsync(int problemId);
        Task<IEnumerable<ProblemDto>> GetAllUserProblemAsync();
        Task UpdateProblemAsync(int problemId, ProblemRequestDto problemUpdateDto);
        Task DeleteProblemAsync(int problemId);
    }
}
