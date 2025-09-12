using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Domain.Entities;

namespace FlowSalong.Application.Features.Customers.Queries;

public record GetCustomerByIdQuery(int Id) : IRequest<OperationResult<Customer>>;
