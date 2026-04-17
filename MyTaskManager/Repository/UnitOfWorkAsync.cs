using MyTaskManager.Data;
using MyTaskManager.Repository.IRepository;

namespace MyTaskManager.Repository
{
    public class UnitOfWorkAsync : IUnitOfWorkAsync
    {
        private readonly ApplicationDbContext _db;

        public ITaskRepositoryAsync TaskItem { get; private set; }
        public UnitOfWorkAsync(ApplicationDbContext db)
        {
            _db = db;
            TaskItem = new TaskRepositoryAsync(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
