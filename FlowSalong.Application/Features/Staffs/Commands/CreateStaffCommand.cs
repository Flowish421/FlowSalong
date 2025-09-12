using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;

namespace FlowSalong.Application.Features.Staffs.Commands;

public record CreateStaffCommand(StaffDto Staff) : IRequest<OperationResult<StaffDto>>;
