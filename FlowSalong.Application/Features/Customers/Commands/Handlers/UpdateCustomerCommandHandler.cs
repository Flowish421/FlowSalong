using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.DTOs;
using FlowSalong.Application.Features.Customers.Commands;
using MediatR;
using FlowSalong.Domain.Common.Interfaces;

namespace FlowSalong.Application.Features.Customers.Commands.Handlers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, OperationResult<CustomerDto>>
{
    private readonly IFlowSalongDbContext _context;

    public UpdateCustomerCommandHandler(IFlowSalongDbContext context)
    {
        _context = context;
    }

    public async Task<OperationResult<CustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == request.Id);

        if (customer == null)
            return OperationResult<CustomerDto>.Fail("Customer not found");

        customer.Name = request.Name;
        customer.Email = request.Email;

        await _context.SaveChangesAsync(cancellationToken);

        var dto = new CustomerDto(customer.Id, customer.Name, customer.Email);
        return OperationResult<CustomerDto>.Ok(dto);
    }
}
