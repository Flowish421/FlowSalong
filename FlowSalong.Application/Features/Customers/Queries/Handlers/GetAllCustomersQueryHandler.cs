using System.Collections.Generic;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Queries;
using FlowSalong.Domain.Entities;
using MediatR;

namespace FlowSalong.Application.Features.Customers.Queries.Handlers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, OperationResult<List<Customer>>>
{
    private readonly ICustomerRepository _repository;

    public GetAllCustomersQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult<List<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _repository.GetAllAsync();
        return OperationResult<List<Customer>>.Ok(customers);
    }
}
