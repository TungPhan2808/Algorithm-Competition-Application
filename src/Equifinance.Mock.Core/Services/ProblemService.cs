using AutoMapper;
using Equifinance.Mock.API.DTO;
using Equifinance.Mock.Core.DTO.Request;
using Equifinance.Mock.Core.Exceptions;
using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Interfaces.IService;
using Equifinance.Mock.Core.Models;

namespace Equifinance.Mock.API.Services
{
    public class ProblemService : IProblemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProblemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProblemDto> CreateProblemAsync(int userId, ProblemRequest problemCreate)
        {
            if (!await _unitOfWork.Problem.IsExistedUser(userId))
            {
                throw new EntityNotFoundException($"No user found with id {userId}.");
            }
            var problem = _mapper.Map<Problem>(problemCreate);
            problem.UserID = userId;
            await _unitOfWork.Problem.AddOneAsync(problem);
            return _mapper.Map<ProblemDto>(problem);
        }

        public async Task<ProblemDto> GetProblemByIdAsync(int problemId)
        {
            var problem = await _unitOfWork.Problem.GetByIdAsync(problemId);
            if (problem == null)
            {
                throw new EntityNotFoundException($"No problem found with ID {problemId}.");
            }
            return _mapper.Map<ProblemDto>(problem);
        }

        public async Task<IEnumerable<ProblemDto>> GetAllUserProblemAsync()
        {
            var problems = await _unitOfWork.Problem.GetAllAsync();
            return _mapper.Map<IEnumerable<ProblemDto>>(problems);
        }

        public async Task UpdateProblemAsync(int problemId, ProblemRequest problemUpdateDto)
        {
            var problem = await _unitOfWork.Problem.GetByIdAsync(problemId);
            if (problem == null)
            {
                throw new EntityNotFoundException($"Problem can not be null.");
            }
            problem.Topic = problemUpdateDto.Topic;
            problem.Description = problemUpdateDto.Description;
            problem.Difficulty = problemUpdateDto.Difficulty;
            await _unitOfWork.Problem.UpdateAsync(problem);
        }
        public async Task DeleteProblemAsync(int problemId)
        {
            var problem = await _unitOfWork.Problem.GetByIdAsync(problemId);
            if (problem == null)
            {
                throw new EntityNotFoundException($"No problem found with ID {problemId}.");
            }
            await _unitOfWork.Problem.RemoveAsync(problem);
        }
    }
}
