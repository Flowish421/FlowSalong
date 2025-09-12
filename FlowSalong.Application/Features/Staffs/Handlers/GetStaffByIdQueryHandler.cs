using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Application.Features.Staffs.Queries;
using FlowSalong.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Staffs.Handlers;

public class GetStaffByIdQueryHandler : IRequestHandler<GetStaffByIdQuery, OperationResult<StaffDto>>
{
    private readonly IRepository<Staff> _repository;

    public GetStaffByIdQueryHandler(IRepository<Staff> repository) => _repository = repository;

    public async Task<OperationResult<StaffDto>> Handle(GetStaffByIdQuery request, CancellationToken cancellationToken)
    {
        var staff = await _repository.GetByIdAsync(request.Id);

        if (staff is null)
            return OperationResult<StaffDto>.Fail("Staff not found");

        return OperationResult<StaffDto>.Ok(new StaffDto
        {
            Id = staff.Id,
            Name = staff.Name,
            Role = staff.Role
        });
    }
}
