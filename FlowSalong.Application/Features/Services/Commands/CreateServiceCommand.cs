using FlowSalong.Application.Common.Models;
using MediatR;

namespace FlowSalong.Application.Features.Services.Commands;

public record CreateServiceCommand(string Name, decimal Price) : IRequest<OperationResult<FlowSalong.Application.Features.Services.DTOs.ServiceDto>>;
