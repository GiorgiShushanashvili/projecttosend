using Microsoft.EntityFrameworkCore;
using ProjectToSend.DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheProjectToSend.Context;

namespace ProjectToSend.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PersonContext _dbcontext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(PersonContext personContext)
        {
            _dbcontext = personContext;
            _dbSet = _dbcontext.Set<T>();
        }
        public virtual async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public virtual async Task DeleteAsync(T entity)
        {
           _dbSet.Remove(entity);
        }

        public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
        {
           return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> FindAsync(string text)
        {
            
            return await _dbSet.FindAsync(text);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return  await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public virtual Task<T> Update(T entity, int id)
        {
            var existing = _dbSet.Find(id);
            if(existing != null)
            {
                _dbcontext.Entry(existing).CurrentValues.SetValues(entity);
            }
            return Task.FromResult(existing);
        }
    }
}
