using FlowSalong.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Infrastructure.Persistence
{
    public class FlowSalongDbContext : DbContext
    {
        public FlowSalongDbContext(DbContextOptions<FlowSalongDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
    }
}
