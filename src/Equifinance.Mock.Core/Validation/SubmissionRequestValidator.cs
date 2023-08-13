using Equifinance.Mock.Core.DTO.Request;
using FluentValidation;

namespace Equifinance.Mock.Core.Validation
{
    public class SubmissionRequestValidator : AbstractValidator<SubmissionRequest>
    {
        public SubmissionRequestValidator()
        {
            RuleFor(x => x.UserID).NotEmpty();
        }
    }
}
