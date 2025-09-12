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
        var existing = await repository.GetByIdAsync(request.Id);
        if (existing is null)
            return OperationResult<bool>.Fail("Service not found");

        await repository.DeleteAsync(existing);
        return OperationResult<bool>.Ok(true);
    }
}
