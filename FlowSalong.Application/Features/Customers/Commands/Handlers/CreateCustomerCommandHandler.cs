using System.Threading;
using System.Threading.Tasks;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Commands;
using FlowSalong.Application.Features.Customers.DTOs;
using FlowSalong.Domain.Common.Interfaces; // 👈 Korrekt namespace för repos
using FlowSalong.Domain.Entities;
using MediatR;

namespace FlowSalong.Application.Features.Customers.Commands.Handlers
{
    public class CreateCustomerCommandHandler
        : IRequestHandler<CreateCustomerCommand, OperationResult<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<CustomerDto>> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email
            };

            await _repository.AddAsync(customer);

            var dto = new CustomerDto(customer.Id, customer.Name, customer.Email);
            return OperationResult<CustomerDto>.Ok(dto);
        }
    }
}
