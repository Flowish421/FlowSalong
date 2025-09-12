using FlowSalong.Application.Common.Models;
using MediatR;

namespace FlowSalong.Application.Features.Services.Commands;

public record UpdateServiceCommand(int Id, string Name, decimal Price) : IRequest<OperationResult<FlowSalong.Application.Features.Services.DTOs.ServiceDto>>;
