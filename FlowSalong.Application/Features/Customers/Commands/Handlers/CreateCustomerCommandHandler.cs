using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Commands;
using FlowSalong.Application.Features.Customers.DTOs;
using FlowSalong.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Customers.Commands.Handlers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, OperationResult<CustomerDto>>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository) => _repository = repository;

    public async Task<OperationResult<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Name = request.Customer.Name,
            Email = request.Customer.Email
        };

        await _repository.AddAsync(customer);

        return OperationResult<CustomerDto>.Ok(new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        });
    }
}
