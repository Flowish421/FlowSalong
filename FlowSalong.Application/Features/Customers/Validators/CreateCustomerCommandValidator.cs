using FluentValidation;
using FlowSalong.Application.Features.Services.Commands;

namespace FlowSalong.Application.Features.Services.Validators
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Tjänstens namn krävs.");

            RuleFor(s => s.Price)
                .GreaterThan(0).WithMessage("Priset måste vara större än 0.");
        }
    }
}
