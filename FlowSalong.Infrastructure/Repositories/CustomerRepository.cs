using FlowSalong.Domain.Entities;
using FlowSalong.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowSalong.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IFlowSalongDbContext _context;

        public CustomerRepository(IFlowSalongDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
