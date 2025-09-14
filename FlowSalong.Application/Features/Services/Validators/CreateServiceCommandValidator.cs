using FlowSalong.Application.Features.Customers.Commands;
using FluentValidation;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
    }
}
