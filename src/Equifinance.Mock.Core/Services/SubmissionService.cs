using Equifinance.Mock.Core.DTO.Request;
using Equifinance.Mock.Core.DTO.Result;
using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Interfaces.IService;

namespace Equifinance.Mock.Core.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubmissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public ValidationResult ValidateSubmission(SubmissionRequest submissionRequest)
        //{
        //    throw new NotImplementedException();
        //}

        public Task EnqueueSubmission(SubmissionRequest submissionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<SubmissionResult> Submit(SubmissionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
