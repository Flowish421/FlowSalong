using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Domain.Common.Interfaces;

namespace FlowSalong.Application.Features.Staffs.Handlers
{
    public class GetAllStaffQueryHandler
    {
        private readonly IFlowSalongDbContext _context;

        public GetAllStaffQueryHandler(IFlowSalongDbContext context)
        {
            _context = context;
        }

        public OperationResult<List<StaffDto>> Handle()
        {
            var staffDtos = _context.Staffs
                .Select(s => new StaffDto(s.Id, s.Name, s.Role))
                .ToList();

            return OperationResult<List<StaffDto>>.Ok(staffDtos);
        }
    }
}
