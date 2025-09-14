using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.DTOs;

namespace FlowSalong.Application.Features.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<OperationResult<CustomerDto>>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }

    }
}
