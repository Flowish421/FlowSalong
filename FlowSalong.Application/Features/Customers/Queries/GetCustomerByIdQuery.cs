using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.DTOs;

namespace FlowSalong.Application.Features.Customers.Queries;

public record GetCustomerByIdQuery(int Id) : IRequest<OperationResult<CustomerDto>>;
