using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.DTOs;
using FlowSalong.Application.Features.Customers.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Customers.Queries.Handlers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, OperationResult<CustomerDto>>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByIdQueryHandler(ICustomerRepository repository) => _repository = repository;

    public async Task<OperationResult<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Id);

        if (existing is null)
            return OperationResult<CustomerDto>.Fail("Customer not found");

        return OperationResult<CustomerDto>.Ok(new CustomerDto
        {
            Id = existing.Id,
            Name = existing.Name,
            Email = existing.Email
        });
    }
}
