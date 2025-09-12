using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Domain.Entities;
using FlowSalong.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FlowSalongDbContext _context;

        public CustomerRepository(FlowSalongDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity == null) return false;
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
