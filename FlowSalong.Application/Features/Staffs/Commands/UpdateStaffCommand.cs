using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using MediatR;

namespace FlowSalong.Application.Features.Staffs.Commands;

public record UpdateStaffCommand(Guid Id, string Name, string Role)
    : IRequest<OperationResult<StaffDto>>;

