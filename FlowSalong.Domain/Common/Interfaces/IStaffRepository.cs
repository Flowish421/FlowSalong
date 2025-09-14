using FlowSalong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowSalong.Domain.Common.Interfaces
{
    public interface IStaffRepository
    {
        Task<Staff?> GetByIdAsync(Guid id);
        Task<List<Staff>> GetAllAsync();
        Task AddAsync(Staff staff);
        Task UpdateAsync(Staff staff);
        Task DeleteAsync(Staff staff);
    }
}
