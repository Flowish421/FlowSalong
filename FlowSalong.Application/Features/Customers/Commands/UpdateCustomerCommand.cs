using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Domain.Entities;
using FlowSalong.Application.Features.Customers.Dtos;

namespace FlowSalong.Application.Features.Customers.Commands;

public record UpdateCustomerCommand(int Id, CustomerUpdateDto CustomerDto) : IRequest<OperationResult<Customer>>;
