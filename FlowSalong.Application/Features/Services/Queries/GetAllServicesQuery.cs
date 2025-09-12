using FlowSalong.Application.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace FlowSalong.Application.Features.Services.Queries;

public record GetAllServicesQuery() : IRequest<OperationResult<List<FlowSalong.Application.Features.Services.DTOs.ServiceDto>>>;
