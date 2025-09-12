using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Queries;
using FlowSalong.Domain.Entities;
using MediatR;

namespace FlowSalong.Application.Features.Customers.Queries.Handlers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, OperationResult<Customer>>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByIdQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult<Customer>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        if (customer == null)
            return OperationResult<Customer>.Fail("Customer not found");

        return OperationResult<Customer>.Ok(customer);
    }
}
