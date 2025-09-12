using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.DTOs;

namespace FlowSalong.Application.Features.Customers.Commands;

public record UpdateCustomerCommand(int Id, CustomerDto Customer) : IRequest<OperationResult<CustomerDto>>;
