using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;
using FlowSalong.Domain.Entities;
using MediatR;

namespace FlowSalong.Application.Features.Services.Queries.Handlers;

public class GetServiceByIdQueryHandler(IRepository<Service> repository)
    : IRequestHandler<GetServiceByIdQuery, OperationResult<ServiceDto>>
{
    public async Task<OperationResult<ServiceDto>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var existing = await repository.GetByIdAsync(request.Id);
        if (existing is null)
            return OperationResult<ServiceDto>.Fail("Service not found");

        var dto = new ServiceDto(existing.Id, existing.Name, existing.Price);
        return OperationResult<ServiceDto>.Ok(dto);
    }
}
