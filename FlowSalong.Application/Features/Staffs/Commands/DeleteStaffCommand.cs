using MediatR;
using FlowSalong.Application.Common.Models;

namespace FlowSalong.Application.Features.Staffs.Commands;

public record DeleteStaffCommand(int Id) : IRequest<OperationResult<bool>>;
