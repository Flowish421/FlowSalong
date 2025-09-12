using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using FlowSalong.Application.Features.Staffs.Queries;
using FlowSalong.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Staffs.Handlers;

public class GetAllStaffQueryHandler : IRequestHandler<GetAllStaffQuery, OperationResult<List<StaffDto>>>
{
    private readonly IRepository<Staff> _repository;

    public GetAllStaffQueryHandler(IRepository<Staff> repository) => _repository = repository;

    public async Task<OperationResult<List<StaffDto>>> Handle(GetAllStaffQuery request, CancellationToken cancellationToken)
    {
        var staffList = await _repository.GetAllAsync();

        var dtos = staffList.Select(s => new StaffDto
        {
            Id = s.Id,
            Name = s.Name,
            Role = s.Role
        }).ToList();

        return OperationResult<List<StaffDto>>.Ok(dtos);
    }
}
