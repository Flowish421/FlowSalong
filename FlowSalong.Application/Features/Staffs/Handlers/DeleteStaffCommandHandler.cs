using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.Commands;
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Application.Features.Staffs.Handlers
{
    // Gör handlern känd för MediatR genom att implementera IRequestHandler
    public class DeleteStaffCommandHandler
        : IRequestHandler<DeleteStaffCommand, OperationResult<bool>>
    {
        private readonly IFlowSalongDbContext _context;

        public DeleteStaffCommandHandler(IFlowSalongDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<bool>> Handle(
            DeleteStaffCommand request,
            CancellationToken cancellationToken)
        {
            // Hämta personal med ID
            var staff = await _context.Staffs
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (staff == null)
                return OperationResult<bool>.Fail("Staff not found");

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync(cancellationToken);

            return OperationResult<bool>.Ok(true);
        }
    }
}
