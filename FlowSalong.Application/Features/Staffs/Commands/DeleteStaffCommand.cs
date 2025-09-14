using FlowSalong.Application.Common.Models;
using MediatR;

namespace FlowSalong.Application.Features.Staffs.Commands;

public record DeleteStaffCommand(Guid Id)
    : IRequest<OperationResult<bool>>;
