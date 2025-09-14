// FlowSalongDbContext.cs
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Infrastructure.Persistence
{
    public class FlowSalongDbContext : DbContext, IFlowSalongDbContext
    {
        public FlowSalongDbContext(DbContextOptions<FlowSalongDbContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; } // 👈 Lägg till detta

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => base.SaveChangesAsync(cancellationToken);
    }
}
