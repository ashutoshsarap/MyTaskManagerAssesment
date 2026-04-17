using MyTaskManager.Models.Entity;

namespace MyTaskManager.Repository.IRepository
{
    public interface ICategoryRepository 
    {
            public void Delete(int id);
            public void Add(CategoryEntity entity);
            public IEnumerable<CategoryEntity> GetAll();
    }
}
