using System.Threading;
using System.Threading.Tasks;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Application.Features.Staffs.Queries;
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Domain.Entities;
using MediatR;

namespace FlowSalong.Application.Features.Staffs.Queries.Handlers
{
    public class GetStaffByIdQueryHandler
        : IRequestHandler<GetStaffByIdQuery, OperationResult<StaffDto>>
    {
        private readonly IRepository<Staff> _repository;

        public GetStaffByIdQueryHandler(IRepository<Staff> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<StaffDto>> Handle(
            GetStaffByIdQuery request,
            CancellationToken cancellationToken)
        {
            // ✅ Hämta Staff via Guid
            var staff = await _repository.GetByIdAsync(request.Id);

            if (staff == null)
                return OperationResult<StaffDto>.Fail("Staff not found");

            var dto = new StaffDto(staff.Id, staff.Name, staff.Role);
            return OperationResult<StaffDto>.Ok(dto);
        }
    }
}
