using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Domain.Entities;
using FlowSalong.Application.Features.Customers.Dtos;

namespace FlowSalong.Application.Features.Customers.Commands;

public record CreateCustomerCommand(CustomerCreateDto CustomerDto) : IRequest<OperationResult<Customer>>;
