using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Commands;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Domain.Entities;

namespace FlowSalong.Application.Features.Customers.Commands.Handlers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, OperationResult<Customer>>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(
            request.CustomerDto.FirstName,
            request.CustomerDto.LastName,
            request.CustomerDto.Email
        );

        await _repository.AddAsync(customer);
        return OperationResult<Customer>.Ok(customer);
    }
}
