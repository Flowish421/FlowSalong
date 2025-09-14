using FlowSalong.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowSalong.Domain.Common.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer customer);
        Task<Customer?> GetByIdAsync(Guid id);
        Task<List<Customer>> GetAllAsync();
    }
}
