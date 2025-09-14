using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Application.Features.Staffs.Queries;
using FlowSalong.Domain.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Application.Features.Staffs.Handlers
{
    public class GetStaffByIdQueryHandler
        : IRequestHandler<GetStaffByIdQuery, OperationResult<StaffDto>>
    {
        private readonly IStaffRepository _repository;

        public GetStaffByIdQueryHandler(IStaffRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<StaffDto>> Handle(
            GetStaffByIdQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var staff = await _repository.GetByIdAsync(request.Id);

                if (staff == null)
                    return OperationResult<StaffDto>.Fail("Staff not found");

                var dto = new StaffDto(staff.Id, staff.Name, staff.Role);
                return OperationResult<StaffDto>.Ok(dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetStaffByIdQueryHandler error: {ex}");
                return OperationResult<StaffDto>.Fail($"Error fetching staff: {ex.Message}");
            }
        }
    }
}
