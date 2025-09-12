using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;
using FlowSalong.Domain.Entities;
using MediatR;

namespace FlowSalong.Application.Features.Services.Commands.Handlers;

public class CreateServiceCommandHandler(IRepository<Service> repository)
    : IRequestHandler<CreateServiceCommand, OperationResult<ServiceDto>>
{
    public async Task<OperationResult<ServiceDto>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = new Service { Name = request.Name, Price = request.Price };
        await repository.AddAsync(entity);

        var dto = new ServiceDto(entity.Id, entity.Name, entity.Price);
        return OperationResult<ServiceDto>.Ok(dto);
    }
}
