using FluentValidation;
using FlowSalong.Application.Features.Staffs.Commands;

namespace FlowSalong.Application.Features.Staffs.Validators
{
    public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
    {
        public CreateStaffCommandValidator()
        {
            RuleFor(x => x.Staff.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Staff.Role)
                .NotEmpty().WithMessage("Role is required");
        }
    }

    public class UpdateStaffCommandValidator : AbstractValidator<UpdateStaffCommand>
    {
        public UpdateStaffCommandValidator()
        {
            RuleFor(x => x.Staff.Id).GreaterThan(0).WithMessage("Staff Id must be provided");
            RuleFor(x => x.Staff.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Staff.Role)
                .NotEmpty().WithMessage("Role is required");
        }
    }
}
