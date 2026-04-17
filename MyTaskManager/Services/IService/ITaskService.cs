using MyTaskManager.Models.DTO;
using MyTaskManager.Models.Entity;
using System.Linq.Expressions;

namespace MyTaskManager.Services.IService
{
    public interface ITaskService
    {
        public void Add(TaskDTO taskDTO);
        public void Delete(int id);
        public IEnumerable<TaskEntity> GetAll(string? includeProperties = null);
        public TaskEntity Get(Expression<Func<TaskEntity, bool>> filter, string? includeProperties = null);
        public void Update(TaskDTO taskDTO);    
    }
}
