using MyTaskManager.Models.Entity;

namespace MyTaskManager.Repository.IRepository
{
    public interface ITaskRepositoryAsync : IRepositoryAsync<TaskEntity>
    {
        public Task<TaskEntity> Update(TaskEntity entity);
    }
}
