using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Commands;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Domain.Entities;

namespace FlowSalong.Application.Features.Customers.Commands.Handlers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, OperationResult<Customer>>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Id);
        if (existing == null)
            return OperationResult<Customer>.Fail("Customer not found");

        var updated = new Customer(
            request.CustomerDto.FirstName,
            request.CustomerDto.LastName,
            request.CustomerDto.Email
        )
        {
            Id = existing.Id // behåll samma Id
        };

        await _repository.UpdateAsync(updated);
        return OperationResult<Customer>.Ok(updated);
    }
}
