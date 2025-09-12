using FlowSalong.Application.Common.Models;
using MediatR;

namespace FlowSalong.Application.Features.Services.Queries;

public record GetServiceByIdQuery(int Id) : IRequest<OperationResult<FlowSalong.Application.Features.Services.DTOs.ServiceDto>>;
