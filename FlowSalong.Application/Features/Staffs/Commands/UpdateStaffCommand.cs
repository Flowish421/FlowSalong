using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;

namespace FlowSalong.Application.Features.Staffs.Commands;

public record UpdateStaffCommand(int Id, StaffDto Staff) : IRequest<OperationResult<StaffDto>>;
