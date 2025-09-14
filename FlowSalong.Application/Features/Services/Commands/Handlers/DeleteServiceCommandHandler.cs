using FlowSalong.Application.Common.Models;
using FlowSalong.Domain.Common.Interfaces;
using MediatR;
using FlowSalong.Application.Features.Services.DTOs;


namespace FlowSalong.Application.Features.Services.Commands.Handlers
{
    public class DeleteServiceCommandHandler
        : IRequestHandler<DeleteServiceCommand, OperationResult<bool>>
    {
        private readonly IFlowSalongDbContext _context;

        public DeleteServiceCommandHandler(IFlowSalongDbContext context) => _context = context;

        public async Task<OperationResult<bool>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _context.Services.FindAsync(new object[] { request.Id }, cancellationToken);
            if (service == null)
                return OperationResult<bool>.Fail("Service not found");

            _context.Services.Remove(service);
            await _context.SaveChangesAsync(cancellationToken);

            return OperationResult<bool>.Ok(true);
        }
    }
}
