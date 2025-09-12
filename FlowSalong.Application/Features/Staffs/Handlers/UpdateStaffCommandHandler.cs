using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.Commands;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Staffs.Handlers;

public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, OperationResult<StaffDto>>
{
    private readonly IRepository<Staff> _repository;

    public UpdateStaffCommandHandler(IRepository<Staff> repository) => _repository = repository;

    public async Task<OperationResult<StaffDto>> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Staff.Id);

        if (existing is null)
            return OperationResult<StaffDto>.Fail("Staff not found");

        existing.Name = request.Staff.Name;
        existing.Role = request.Staff.Role;

        await _repository.UpdateAsync(existing);

        return OperationResult<StaffDto>.Ok(new StaffDto
        {
            Id = existing.Id,
            Name = existing.Name,
            Role = existing.Role
        });
    }
}
