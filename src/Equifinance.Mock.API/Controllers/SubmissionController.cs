using Equifinance.Mock.Core.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace Equifinance.Mock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        //[HttpPost]
        //public async Task<ActionResult> Submit([FromBody] Submission submission)
        //{
        //    var submissionResult = await _submissionService.SubmitAsync(submission);
        //    return Ok(submissionResult);
        //}
    }
}
