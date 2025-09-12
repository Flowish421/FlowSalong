using MediatR;
using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Customers.Commands;
using FlowSalong.Application.Common.Interfaces;

namespace FlowSalong.Application.Features.Customers.Commands.Handlers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, OperationResult<bool>>
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        // Hämta först customer
        var existing = await _repository.GetByIdAsync(request.Id);
        if (existing == null)
            return OperationResult<bool>.Fail("Customer not found");

        // Skicka endast Id eller Customer till repository beroende på signatur
        await _repository.DeleteAsync(request.Id); // <-- ändrat från 'existing' till 'request.Id'

        return OperationResult<bool>.Ok(true);
    }
}
