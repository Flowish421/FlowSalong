using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Commands;
using FlowSalong.Application.Features.Customers.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Customers.Commands.Handlers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, OperationResult<CustomerDto>>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerCommandHandler(ICustomerRepository repository) => _repository = repository;

    public async Task<OperationResult<CustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Hämta kunden via repository
        var existingCustomer = await _repository.GetByIdAsync(request.Customer.Id);

        if (existingCustomer == null)
            return OperationResult<CustomerDto>.Fail("Customer not found");

        // Uppdatera fälten
        existingCustomer.Name = request.Customer.Name;
        existingCustomer.Email = request.Customer.Email;

        await _repository.UpdateAsync(existingCustomer);

        // Returnera resultat
        return OperationResult<CustomerDto>.Ok(new CustomerDto
        {
            Id = existingCustomer.Id,
            Name = existingCustomer.Name,
            Email = existingCustomer.Email
        });
    }
}
