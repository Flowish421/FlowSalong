using FluentValidation;
using FlowSalong.Application.Features.Customers.Commands;

namespace FlowSalong.Application.Features.Customers.Validators
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            // Id får inte vara tomt (Guid.Empty)
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id får inte vara tomt.");

            // Namn och e-post som vid Create
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Namn krävs.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-post krävs.")
                .EmailAddress().WithMessage("Ogiltig e-postadress.");
        }
    }
}
