using System.Threading;
using System.Threading.Tasks;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.DTOs;
using FlowSalong.Application.Features.Customers.Queries;
using FlowSalong.Domain.Common.Interfaces;
using MediatR;

namespace FlowSalong.Application.Features.Customers.Queries.Handlers
{
    public class GetCustomerByIdQueryHandler
        : IRequestHandler<GetCustomerByIdQuery, OperationResult<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<CustomerDto>> Handle(
            GetCustomerByIdQuery request,
            CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);

            if (customer == null)
                return OperationResult<CustomerDto>.Fail("Customer not found");

            var dto = new CustomerDto(customer.Id, customer.Name, customer.Email);
            return OperationResult<CustomerDto>.Ok(dto);
        }
    }
}
