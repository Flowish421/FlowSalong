using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FlowSalong.Domain.Common.Interfaces;
using FlowSalong.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlowSalong.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FlowSalongDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(FlowSalongDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        // 🔄 Ändra från int till Guid
        public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);

        public void Update(T entity) => _dbSet.Update(entity);
    }
}
