using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using MediatR;

namespace FlowSalong.Application.Features.Staffs.Queries;

public record GetStaffByIdQuery(int Id) : IRequest<OperationResult<StaffDto>>;
