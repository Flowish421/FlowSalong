using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.Commands;
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Application.Features.Services.DTOs;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Services.Commands.Handlers
{
    public class CreateServiceCommandHandler
        : IRequestHandler<CreateServiceCommand, OperationResult<ServiceDto>>
    {
        private readonly IRepository<FlowSalong.Domain.Entities.Service> _repository;

        public CreateServiceCommandHandler(IRepository<FlowSalong.Domain.Entities.Service> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<ServiceDto>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new FlowSalong.Domain.Entities.Service
            {
                // Använd Guid som ID om din entity har Guid, annars lämna Id (int) som EF genererar.
                Name = request.Name,
                Price = request.Price
            };

            await _repository.AddAsync(service);
            return OperationResult<ServiceDto>.Ok(
                new ServiceDto(service.Id, service.Name, service.Price)
            );
        }
    }
}
