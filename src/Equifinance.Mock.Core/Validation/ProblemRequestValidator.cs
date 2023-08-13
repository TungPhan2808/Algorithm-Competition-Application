using Equifinance.Mock.Core.DTO.Request;
using FluentValidation;

namespace Equifinance.Mock.Core.Validation
{
    public class ProblemRequestValidator : AbstractValidator<ProblemRequest>
    {
        public ProblemRequestValidator()
        {
            RuleFor(x => x.Topic).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Difficulty).NotEmpty();
        }
    }
}
