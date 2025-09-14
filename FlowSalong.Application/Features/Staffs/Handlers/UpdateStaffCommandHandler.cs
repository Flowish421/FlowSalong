using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.Commands;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Domain.Common.Interfaces;
using MediatR;

namespace FlowSalong.Application.Features.Staffs.Handlers;

public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, OperationResult<StaffDto>>
{
    private readonly IFlowSalongDbContext _context;

    public UpdateStaffCommandHandler(IFlowSalongDbContext context)
    {
        _context = context;
    }

    public async Task<OperationResult<StaffDto>> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
    {
        var staff = _context.Staffs.FirstOrDefault(s => s.Id == request.Id);
        if (staff == null)
            return OperationResult<StaffDto>.Fail("Staff not found");

        staff.Name = request.Name;
        staff.Role = request.Role;

        await _context.SaveChangesAsync(cancellationToken);

        var staffDto = new StaffDto(staff.Id, staff.Name, staff.Role);
        return OperationResult<StaffDto>.Ok(staffDto);
    }
}
