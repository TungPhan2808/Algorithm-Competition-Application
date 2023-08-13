using Equifinance.Mock.Core.DTO.Request;
using Equifinance.Mock.Core.DTO.Result;

namespace Equifinance.Mock.Core.Interfaces.IService
{
    public interface ISubmissionService
    {
        Task<SubmissionResult> Submit(SubmissionRequest request);
        //ValidationResult ValidateSubmission(SubmissionRequest submissionRequest);
        Task EnqueueSubmission(SubmissionRequest submissionRequest);
    }
}
