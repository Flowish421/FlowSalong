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
        var existing = await repository.GetByIdAsync(request.Id);
        if (existing is null)
            return OperationResult<ServiceDto>.Fail("Service not found");

        existing.Name = request.Name;
        existing.Price = request.Price;

        await repository.UpdateAsync(existing);

        var dto = new ServiceDto(existing.Id, existing.Name, existing.Price);
        return OperationResult<ServiceDto>.Ok(dto);
    }
}
