using FluentValidation;
using FlowSalong.Application.Features.Staffs.Commands;

namespace FlowSalong.Application.Features.Staffs.Validators
{
    public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
    {
        public CreateStaffCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required")
                .MaximumLength(50).WithMessage("Role cannot exceed 50 characters");
        }
    }

    public class UpdateStaffCommandValidator : AbstractValidator<UpdateStaffCommand>
    {
        public UpdateStaffCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");


            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required")
                .MaximumLength(50).WithMessage("Role cannot exceed 50 characters");
        }
    }
}
