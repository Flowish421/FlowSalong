using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;


namespace FlowSalong.Application.Features.Services.Commands
{
    public class UpdateServiceCommand : MediatR.IRequest<OperationResult<ServiceDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
