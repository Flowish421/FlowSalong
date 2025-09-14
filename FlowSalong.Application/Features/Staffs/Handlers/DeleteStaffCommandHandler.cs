using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.Commands;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Domain.Entities;
using FlowSalong.Domain.Common.Interfaces;

namespace FlowSalong.Application.Features.Staffs.Handlers
{
    public class DeleteStaffCommandHandler
    {
        private readonly IFlowSalongDbContext _context;

        public DeleteStaffCommandHandler(IFlowSalongDbContext context)
        {
            _context = context;
        }

        public OperationResult<bool> Handle(DeleteStaffCommand request)
        {
            var staff = _context.Staffs.FirstOrDefault(s => s.Id == request.Id);
            if (staff == null)
                return OperationResult<bool>.Fail("Staff not found");

            _context.Staffs.Remove(staff);
            return OperationResult<bool>.Ok(true);
        }
    }
}
