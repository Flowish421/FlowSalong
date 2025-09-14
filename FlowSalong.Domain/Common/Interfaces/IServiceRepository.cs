using FlowSalong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowSalong.Domain.Common.Interfaces
{
    public interface IServiceRepository
    {
        Task<Service?> GetByIdAsync(Guid id);
        Task<List<Service>> GetAllAsync();
        Task AddAsync(Service service);
        Task UpdateAsync(Service service);
        Task DeleteAsync(Service service);
    }
}
