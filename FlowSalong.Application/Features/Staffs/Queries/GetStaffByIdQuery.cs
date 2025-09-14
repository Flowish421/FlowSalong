using System;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Staffs.DTOs;
using MediatR;

namespace FlowSalong.Application.Features.Staffs.Queries
{
    public class GetStaffByIdQuery : IRequest<OperationResult<StaffDto>>
    {
        public Guid Id { get; set; }
    }
}
