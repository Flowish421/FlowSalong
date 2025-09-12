using FlowSalong.Application.Common.Interfaces;
using FlowSalong.Domain.Entities;
using FlowSalong.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Infrastructure.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(FlowSalongDbContext context) : base(context) { }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }
}
