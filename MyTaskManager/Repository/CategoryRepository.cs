using MyTaskManager.Data;
using MyTaskManager.Models.Entity;
using MyTaskManager.Repository.IRepository;

namespace MyTaskManager.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(CategoryEntity entity)
        {
            _db.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(u => u.Id==id);
            if (category != null)
            {
                _db.Categories.Remove(category);
            }
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return _db.Categories.ToList();
        }


    }
}
