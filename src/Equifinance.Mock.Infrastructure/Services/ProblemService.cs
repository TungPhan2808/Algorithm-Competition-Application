using AutoMapper;
using Equifinance.Mock.API.Data;
using Equifinance.Mock.API.DTO;
using Equifinance.Mock.API.Interfaces;
using Equifinance.Mock.API.Models;
using Equifinance.Mock.API.Repository;

namespace Equifinance.Mock.API.Services
{
    public class ProblemService : IProblemService
    {
        private readonly IProblemRepository _problemRepository;
        private readonly IMapper _mapper;

        public ProblemService(DataContext context, IMapper mapper)
        {
            _problemRepository = new ProblemRepository(context);
            _mapper = mapper;
        }

        public async Task<ProblemDto> CreateProblemAsync(int userId, ProblemRequestDto problemCreateDto)
        {
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
            await _problemRepository.InsertAsync(problem);
            return _mapper.Map<ProblemDto>(problem);
        }

        public async Task<ProblemDto> GetProblemByIdAsync(int problemId)
        {
            var problem = await _problemRepository.GetByIdAsync(problemId);
            if (problem == null)
            {
                Exception exception = new Exception($"Problem with ID {problemId} not found.");
                throw exception;
            }
            return _mapper.Map<ProblemDto>(problem);
        }

        public async Task<IEnumerable<ProblemDto>> GetAllUserProblemAsync()
        {
            var problems = await _problemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProblemDto>>(problems);
        }

        public async Task UpdateProblemAsync(int problemId, ProblemRequestDto problemUpdateDto)
        {
            var problem = await _problemRepository.GetByIdAsync(problemId);
            if (problem == null)
            {
                NullReferenceException nullReferenceException = new NullReferenceException("Problem cannot be null."); throw nullReferenceException;
            }
            problem.Topic = problemUpdateDto.Topic;
            problem.Description = problemUpdateDto.Description;
            problem.Difficulty = problemUpdateDto.Difficulty;
            await _problemRepository.UpdateAsync(problem);
        }
        public async Task DeleteProblemAsync(int problemId)
        {
            var problem = await _problemRepository.GetByIdAsync(problemId);
            if (problem == null)
            {
                Exception exception = new Exception($"Problem {problemId} is not found");
                throw exception;
            }
            await _problemRepository.DeleteAsync(problemId);
        }
    }
}
