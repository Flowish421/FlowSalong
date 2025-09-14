using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Domain.Entities;
using FlowSalong.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IFlowSalongDbContext _context;

        public ServiceRepository(IFlowSalongDbContext context)
        {
            _context = context;
        }

        public async Task<Service?> GetByIdAsync(Guid id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<List<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task AddAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Service service)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
    }
}
