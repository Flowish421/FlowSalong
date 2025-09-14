using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.DTOs;
using MediatR;

namespace FlowSalong.Application.Features.Customers.Commands;

public record UpdateCustomerCommand(Guid Id, string Name, string Email)
    : IRequest<OperationResult<CustomerDto>>;

