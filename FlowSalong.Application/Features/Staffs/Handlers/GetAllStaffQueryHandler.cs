using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Application.Features.Staffs.Queries;
using FlowSalong.Domain.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Application.Features.Staffs.Handlers
{
    public class GetAllStaffQueryHandler
        : IRequestHandler<GetAllStaffQuery, OperationResult<List<StaffDto>>>
    {
        private readonly IFlowSalongDbContext _context;

        public GetAllStaffQueryHandler(IFlowSalongDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<List<StaffDto>>> Handle(
            GetAllStaffQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var staffList = await _context.Staffs.ToListAsync(cancellationToken);

                var staffDtos = staffList
                    .Select(s => new StaffDto(s.Id, s.Name, s.Role))
                    .ToList();

                return OperationResult<List<StaffDto>>.Ok(staffDtos);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllStaffQueryHandler error: {ex}");
                return OperationResult<List<StaffDto>>.Fail($"Error fetching staff: {ex.Message}");
            }
        }
    }
}
