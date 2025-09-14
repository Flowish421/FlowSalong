using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;


namespace FlowSalong.Application.Features.Services.Commands
{
    public class CreateServiceCommand : MediatR.IRequest<OperationResult<ServiceDto>>
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
