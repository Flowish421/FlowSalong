using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;

namespace FlowSalong.Application.Features.Services.Queries
{
    public class GetAllServicesQuery : MediatR.IRequest<OperationResult<List<ServiceDto>>> { }
}
