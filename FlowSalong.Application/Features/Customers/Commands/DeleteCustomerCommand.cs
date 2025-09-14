using MediatR;
using FlowSalong.Application.Common.Models;

namespace FlowSalong.Application.Features.Customers.Commands;

public record DeleteCustomerCommand(Guid Id)
    : IRequest<OperationResult<bool>>;

