using FlowSalong.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Infrastructure.Persistence;

public class FlowSalongDbContext : DbContext
{
    public FlowSalongDbContext(DbContextOptions<FlowSalongDbContext> options) : base(options) { }

    public DbSet<Service> Services { get; set; } = null!;

    // existerande DbSets (Customers etc)
    // public DbSet<Customer> Customers { get; set; } = null!;
}
