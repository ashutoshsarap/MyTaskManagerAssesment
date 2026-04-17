using MyTaskManager.Data;
using MyTaskManager.Repository.IRepository;

namespace MyTaskManager.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ITaskRepository TaskItem { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            TaskItem = new TaskRepository(_db);
            Category = new CategoryRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
