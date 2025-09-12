using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Domain.Entities;
using System.Collections.Generic;

namespace FlowSalong.Application.Features.Customers.Queries;

public record GetAllCustomersQuery() : IRequest<OperationResult<List<Customer>>>;
