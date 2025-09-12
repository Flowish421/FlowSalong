using FluentValidation;
using FlowSalong.Application.Features.Services.Commands;

namespace FlowSalong.Application.Features.Services.Validators
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Service name is required")
                .MaximumLength(100).WithMessage("Service name cannot exceed 100 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }

    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Service Id must be provided");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Service name is required")
                .MaximumLength(100).WithMessage("Service name cannot exceed 100 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
