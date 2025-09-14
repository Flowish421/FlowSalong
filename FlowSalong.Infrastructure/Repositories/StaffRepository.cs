using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Domain.Entities;
using FlowSalong.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Infrastructure.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly IFlowSalongDbContext _context;

        public StaffRepository(IFlowSalongDbContext context)
        {
            _context = context;
        }

        public async Task<Staff?> GetByIdAsync(Guid id) =>
            await _context.Staffs.FindAsync(id);

        public async Task<List<Staff>> GetAllAsync() =>
            await _context.Staffs.ToListAsync();

        public async Task AddAsync(Staff staff)
        {
            _context.Staffs.Add(staff);
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
