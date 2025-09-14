using FlowSalong.Application.Common.Models;
using FlowSalong.Application.Features.Services.DTOs;
using FlowSalong.Application.Features.Services.Queries;
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Application.Features.Services.Queries.Handlers
{
    public class GetServiceByIdQueryHandler
        : IRequestHandler<GetServiceByIdQuery, OperationResult<ServiceDto>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<ServiceDto>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            // request.Id ska vara Guid
            var service = await _repository.GetByIdAsync(request.Id);

            if (service == null)
                return OperationResult<ServiceDto>.Fail("Service not found");

            return OperationResult<ServiceDto>.Ok(
                new ServiceDto(service.Id, service.Name, service.Price)
            );
        }
    }
}
