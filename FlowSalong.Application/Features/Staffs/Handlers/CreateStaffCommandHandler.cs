using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.Commands;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Staffs.Handlers;

public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, OperationResult<StaffDto>>
{
    private readonly IRepository<Staff> _repository;

    public CreateStaffCommandHandler(IRepository<Staff> repository) => _repository = repository;

    public async Task<OperationResult<StaffDto>> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
    {
        var staff = new Staff
        {
            Name = request.Staff.Name,
            Role = request.Staff.Role
        };

        await _repository.AddAsync(staff);

        return OperationResult<StaffDto>.Ok(new StaffDto
        {
            Id = staff.Id,
            Name = staff.Name,
            Role = staff.Role
        });
    }
}
