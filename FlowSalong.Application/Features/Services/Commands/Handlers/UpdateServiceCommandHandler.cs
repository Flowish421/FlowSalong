using FlowSalong.Application.Common.Models;
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Application.Features.Services.DTOs;
using MediatR;

namespace FlowSalong.Application.Features.Services.Commands.Handlers
{
    public class UpdateServiceCommandHandler
        : IRequestHandler<UpdateServiceCommand, OperationResult<ServiceDto>>
    {
        private readonly IFlowSalongDbContext _context;

        public UpdateServiceCommandHandler(IFlowSalongDbContext context) => _context = context;

        public async Task<OperationResult<ServiceDto>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _context.Services.FindAsync(new object[] { request.Id }, cancellationToken);
            if (service == null)
                return OperationResult<ServiceDto>.Fail("Service not found");

            service.Name = request.Name;
            service.Price = request.Price;
            await _context.SaveChangesAsync(cancellationToken);

            return OperationResult<ServiceDto>.Ok(new ServiceDto(service.Id, service.Name, service.Price));
        }
    }
}
