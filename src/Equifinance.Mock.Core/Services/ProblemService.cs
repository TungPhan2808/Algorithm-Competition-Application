using AutoMapper;
using Equifinance.Mock.API.DTO;
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

        public async Task<ProblemDto> CreateProblemAsync(int userId, ProblemRequestDto problemCreateDto)
        {
            if (_unitOfWork.Problem.IsExistedUser(userId))
            {
                Exception exception = new Exception($"User {userId} not found");
                throw exception;
            }
            var problem = _mapper.Map<Problem>(problemCreateDto);
            if (problem == null)
            {
                NullReferenceException nullReferenceException = new NullReferenceException("Problem cannot be null.");
                throw nullReferenceException;
            }
            if (problem.Topic == null)
            {
                NullReferenceException nullReferenceException = new NullReferenceException("Problem topic cannot be null.");
                throw nullReferenceException;
            }
            if (problem.Description == null)
            {
                NullReferenceException nullReferenceException = new NullReferenceException("Problem describtion cannot be null.");
                throw nullReferenceException;
            }
            if (problem.Difficulty == null)
            {
                NullReferenceException nullReferenceException = new NullReferenceException("Problem difficulty cannot be null.");
                throw nullReferenceException;
            }
            problem.UserID = userId;
            await _unitOfWork.Problem.AddOneAsync(problem);
            return _mapper.Map<ProblemDto>(problem);
        }

        public async Task<ProblemDto> GetProblemByIdAsync(int problemId)
        {
            var problem = await _unitOfWork.Problem.GetByIdAsync(problemId);
            if (problem == null)
            {
                Exception exception = new Exception($"Problem with ID {problemId} not found.");
                throw exception;
            }
            return _mapper.Map<ProblemDto>(problem);
        }

        public async Task<IEnumerable<ProblemDto>> GetAllUserProblemAsync()
        {
            var problems = await _unitOfWork.Problem.GetAllAsync();
            return _mapper.Map<IEnumerable<ProblemDto>>(problems);
        }

        public async Task UpdateProblemAsync(int problemId, ProblemRequestDto problemUpdateDto)
        {
            var problem = await _unitOfWork.Problem.GetByIdAsync(problemId);
            if (problem == null)
            {
                NullReferenceException nullReferenceException = new NullReferenceException("Problem cannot be null."); throw nullReferenceException;
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
                Exception exception = new Exception($"Problem {problemId} is not found");
                throw exception;
            }
            await _unitOfWork.Problem.RemoveAsync(problem);
        }
    }
}
