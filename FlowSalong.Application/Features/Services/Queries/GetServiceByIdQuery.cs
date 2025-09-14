using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;


namespace FlowSalong.Application.Features.Services.Queries
{
    public class GetServiceByIdQuery : MediatR.IRequest<OperationResult<ServiceDto>>
    {
        public Guid Id { get; set; }
    }
}
