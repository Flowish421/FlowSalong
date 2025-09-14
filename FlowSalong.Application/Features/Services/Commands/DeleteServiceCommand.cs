using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;


namespace FlowSalong.Application.Features.Services.Commands
{
    public class DeleteServiceCommand : MediatR.IRequest<OperationResult<bool>>
    {
        public Guid Id { get; set; }
    }
}
