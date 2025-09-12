using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Domain.Entities;
using MediatR;

namespace FlowSalong.Application.Features.Services.Commands.Handlers;

public class DeleteServiceCommandHandler(IRepository<Service> repository)
    : IRequestHandler<DeleteServiceCommand, OperationResult<bool>>
{
    public async Task<OperationResult<bool>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity is null)
            return OperationResult<bool>.Fail("Service not found");

        await repository.DeleteAsync(entity);
        return OperationResult<bool>.Ok(true);
    }
}
