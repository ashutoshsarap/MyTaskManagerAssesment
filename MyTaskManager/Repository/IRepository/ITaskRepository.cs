using MyTaskManager.Models.Entity;

namespace MyTaskManager.Repository.IRepository
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {

        public void Update(TaskEntity entity);

    }
}
