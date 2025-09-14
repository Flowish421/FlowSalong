using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Domain.Entities;
using FlowSalong.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowSalong.Infrastructure.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly IFlowSalongDbContext _context;

        public StaffRepository(IFlowSalongDbContext context)
        {
            _context = context;
        }

        public async Task<Staff?> GetByIdAsync(Guid id)
        {
            
            return await _context.Staffs.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Staff>> GetAllAsync()
        {
            return await _context.Staffs.ToListAsync();
        }

        public async Task AddAsync(Staff staff)
        {
            await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync(default);
        }

        public async Task UpdateAsync(Staff staff)
        {
            _context.Staffs.Update(staff);
            await _context.SaveChangesAsync(default);
        }

        public async Task DeleteAsync(Staff staff)
        {
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync(default);
        }
    }
}
