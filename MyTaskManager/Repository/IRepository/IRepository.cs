using System.Linq.Expressions;

namespace MyTaskManager.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);
        public void Delete(T entity);
        public IEnumerable<T> GetAll(string? includeProperties = null);
        public T Get(Expression<Func<T, bool>>? filter, string? includeProperties = null);
    }
}
