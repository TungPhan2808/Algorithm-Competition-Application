using Equifinance.Mock.API.DTO;
using Equifinance.Mock.Core.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace Equifinance.Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private readonly IProblemService _problemService;
        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProblems()
        {
            var problems = await _problemService.GetAllUserProblemAsync();
            return Ok(problems);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProblemById(int id)
        {
            var problem = await _problemService.GetProblemByIdAsync(id);
            return Ok(problem);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProblem(int userId, [FromBody] ProblemRequestDto problemCreateDto)
        {
            var problem = await _problemService.CreateProblemAsync(userId, problemCreateDto);
            return CreatedAtAction(nameof(GetProblemById), new { id = problem.ProblemID }, problem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProblem(int id, ProblemRequestDto problemUpdateDto)
        {
            try
            {
                await _problemService.UpdateProblemAsync(id, problemUpdateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblem(int id)
        {
            await _problemService.DeleteProblemAsync(id);
            return NoContent();
        }
    }
}
