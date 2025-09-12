using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using MediatR;

namespace FlowSalong.Application.Features.Staffs.Queries;

public record GetAllStaffQuery() : IRequest<OperationResult<List<StaffDto>>>;
