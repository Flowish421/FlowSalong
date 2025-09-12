using FlowSalong.Application.Common.Models;
using MediatR;

namespace FlowSalong.Application.Features.Services.Commands;

public record DeleteServiceCommand(int Id) : IRequest<OperationResult<bool>>;
