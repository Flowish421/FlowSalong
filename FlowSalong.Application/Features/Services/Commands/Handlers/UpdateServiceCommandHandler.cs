using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;
using FlowSalong.Domain.Entities;
using MediatR;

namespace FlowSalong.Application.Features.Services.Commands.Handlers;

public class UpdateServiceCommandHandler(IRepository<Service> repository)
    : IRequestHandler<UpdateServiceCommand, OperationResult<ServiceDto>>
{
    public async Task<OperationResult<ServiceDto>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity is null)
            return OperationResult<ServiceDto>.Fail("Service not found");

        entity.Name = request.Name;
        entity.Price = request.Price;

        await repository.UpdateAsync(entity);

        var dto = new ServiceDto(entity.Id, entity.Name, entity.Price);
        return OperationResult<ServiceDto>.Ok(dto);
    }
}
