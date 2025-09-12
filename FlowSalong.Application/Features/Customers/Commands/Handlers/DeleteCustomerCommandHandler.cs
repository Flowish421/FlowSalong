using MediatR;
using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Customers.Commands.Handlers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, OperationResult<bool>>
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerCommandHandler(ICustomerRepository repository) => _repository = repository;

    public async Task<OperationResult<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Id);

        if (existing is null)
            return OperationResult<bool>.Fail("Customer not found");

        await _repository.DeleteAsync(existing);

        return OperationResult<bool>.Ok(true);
    }
}
