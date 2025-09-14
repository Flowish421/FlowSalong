// IFlowSalongDbContext.cs
using FlowSalong.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FlowSalong.Domain.Common.Interfaces
{
    public interface IFlowSalongDbContext
    {
        DbSet<Service> Services { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Staff> Staffs { get; set; } // 👈 Lägg till detta

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
