using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.DTOs;
using FlowSalong.Application.Features.Customers.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Customers.Queries.Handlers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, OperationResult<List<CustomerDto>>>
{
    private readonly ICustomerRepository _repository;

    public GetAllCustomersQueryHandler(ICustomerRepository repository) => _repository = repository;

    public async Task<OperationResult<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetAllAsync();

        var dtos = existing.Select(c => new CustomerDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email
        }).ToList();

        return OperationResult<List<CustomerDto>>.Ok(dtos);
    }
}
