using FlowSalong.Application.Common.Models;
using FlowSalong.Domain.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FlowSalong.Application.Features.Services.DTOs;


namespace FlowSalong.Application.Features.Services.Queries.Handlers
{
    public class GetAllServicesQueryHandler
        : IRequestHandler<GetAllServicesQuery, OperationResult<List<ServiceDto>>>
    {
        private readonly IFlowSalongDbContext _context;

        public GetAllServicesQueryHandler(IFlowSalongDbContext context) => _context = context;

        public async Task<OperationResult<List<ServiceDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _context.Services
                .Select(s => new ServiceDto(s.Id, s.Name, s.Price))
                .ToListAsync(cancellationToken);

            return OperationResult<List<ServiceDto>>.Ok(services);
        }
    }
}
