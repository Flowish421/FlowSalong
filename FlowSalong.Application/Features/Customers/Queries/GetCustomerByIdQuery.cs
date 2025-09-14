using System;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.DTOs;
using MediatR;

namespace FlowSalong.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<OperationResult<CustomerDto>>
    {
        public Guid Id { get; set; }   
    }
}
