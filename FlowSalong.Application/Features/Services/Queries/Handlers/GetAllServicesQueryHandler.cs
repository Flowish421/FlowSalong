using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;
using FlowSalong.Domain.Entities;
using MediatR;
using System.Linq;
using System.Collections.Generic;

namespace FlowSalong.Application.Features.Services.Queries.Handlers;

public class GetAllServicesQueryHandler(IRepository<Service> repository)
    : IRequestHandler<GetAllServicesQuery, OperationResult<List<ServiceDto>>>
{
    public async Task<OperationResult<List<ServiceDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllAsync();
        var dtos = entities.Select(s => new ServiceDto(s.Id, s.Name, s.Price)).ToList();
        return OperationResult<List<ServiceDto>>.Ok(dtos);
    }
}
