using MyTaskManager.Data;
using MyTaskManager.Models.Entity;
using MyTaskManager.Repository.IRepository;

namespace MyTaskManager.Repository
{
    public class TaskRepositoryAsync : RepositoryAsync<TaskEntity>, ITaskRepositoryAsync
    {

        private readonly ApplicationDbContext _db;
        public TaskRepositoryAsync(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<TaskEntity> Update(TaskEntity entity)
        {
            var taskFromDb = _db.TaskItems.FirstOrDefault(u => u.Id == entity.Id);

            if (taskFromDb != null)
            {
                taskFromDb.Title = entity.Title;
                taskFromDb.Description = entity.Description;
                taskFromDb.DueDate = entity.DueDate;
                taskFromDb.Priority = entity.Priority;
                taskFromDb.CategoryId = entity.CategoryId;
            }
             return taskFromDb;
        }
    }
}
