using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.Commands;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Staffs.Handlers
{
    public class CreateStaffCommandHandler
        : IRequestHandler<CreateStaffCommand, OperationResult<StaffDto>>
    {
        private readonly IFlowSalongDbContext _context;

        public CreateStaffCommandHandler(IFlowSalongDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<StaffDto>> Handle(
            CreateStaffCommand request,
            CancellationToken cancellationToken)
        {
            var staff = new Staff
            {
                Id = Guid.NewGuid(),      // 🔑 Generera nytt Guid för Staff
                Name = request.Name,
                Role = request.Role
            };

            _context.Staffs.Add(staff);   // ✅ Använder DbSet<Staff> Staffs
            await _context.SaveChangesAsync(cancellationToken);

            var staffDto = new StaffDto(staff.Id, staff.Name, staff.Role);
            return OperationResult<StaffDto>.Ok(staffDto);
        }
    }
}
