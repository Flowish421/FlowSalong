using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;
using FlowSalong.Domain.Entities;
using MediatR;

namespace FlowSalong.Application.Features.Services.Queries.Handlers;

public class GetAllServicesQueryHandler(IRepository<Service> repository)
    : IRequestHandler<GetAllServicesQuery, OperationResult<List<ServiceDto>>>
{
    public async Task<OperationResult<List<ServiceDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var all = await repository.GetAllAsync();
        var dtos = all.Select(s => new ServiceDto(s.Id, s.Name, s.Price)).ToList();
        return OperationResult<List<ServiceDto>>.Ok(dtos);
    }
}
