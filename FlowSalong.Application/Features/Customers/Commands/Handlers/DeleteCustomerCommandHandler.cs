using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Commands;
using MediatR;
using FlowSalong.Domain.Common.Interfaces;

namespace FlowSalong.Application.Features.Customers.Commands.Handlers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, OperationResult<bool>>
{
    private readonly IFlowSalongDbContext _context;

    public DeleteCustomerCommandHandler(IFlowSalongDbContext context)
    {
        _context = context;
    }

    public async Task<OperationResult<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == request.Id);
        if (customer == null)
            return OperationResult<bool>.Fail("Customer not found");

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync(cancellationToken);

        return OperationResult<bool>.Ok(true);
    }
}
