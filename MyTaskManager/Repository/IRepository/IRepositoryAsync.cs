using System.Linq.Expressions;

namespace MyTaskManager.Repository.IRepository
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}