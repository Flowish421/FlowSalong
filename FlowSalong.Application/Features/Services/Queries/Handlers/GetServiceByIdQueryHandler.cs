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
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity is null)
            return OperationResult<ServiceDto>.Fail("Service not found");

        var dto = new ServiceDto(entity.Id, entity.Name, entity.Price);
        return OperationResult<ServiceDto>.Ok(dto);
    }
}
