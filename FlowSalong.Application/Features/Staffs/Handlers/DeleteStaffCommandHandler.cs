using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.Commands;
using FlowSalong.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Staffs.Handlers;

public class DeleteStaffCommandHandler : IRequestHandler<DeleteStaffCommand, OperationResult<bool>>
{
    private readonly IRepository<Staff> _repository;

    public DeleteStaffCommandHandler(IRepository<Staff> repository) => _repository = repository;

    public async Task<OperationResult<bool>> Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Id);

        if (existing is null)
            return OperationResult<bool>.Fail("Staff not found");

        await _repository.DeleteAsync(existing);

        return OperationResult<bool>.Ok(true);
    }
}
