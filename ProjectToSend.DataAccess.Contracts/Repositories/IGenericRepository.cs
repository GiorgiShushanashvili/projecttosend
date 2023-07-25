using System.Linq.Expressions;

namespace ProjectToSend.DataAccess.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
        public Task<T> FindAsync(string text);
        public Task DeleteAsync(T entity);
        public Task<T> Update(T entity,int id);
        public Task AddAsync(T entity);

    }
}
