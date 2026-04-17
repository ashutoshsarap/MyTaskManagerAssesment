using MyTaskManager.Models.DTO;
using MyTaskManager.Models.Entity;
using MyTaskManager.Repository.IRepository;
using MyTaskManager.Services.IService;
using System.Linq.Expressions;

namespace MyTaskManager.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(TaskDTO taskDTO)
        {
            if(_unitOfWork.TaskItem.Get(t => t.Id == taskDTO.Id) != null)
            {
                throw new Exception("Task with the same ID already exists.");
            }
            _unitOfWork.TaskItem.Add(new TaskEntity
            {
                Id = taskDTO.Id,
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                DueDate = taskDTO.DueDate,
                Priority = taskDTO.Priority,
                CategoryId = taskDTO.CategoryId
            });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var taskItem = _unitOfWork.TaskItem.Get(t => t.Id == id);
            if (taskItem == null)
            {
                throw new Exception("Task not found.");
            }
            _unitOfWork.TaskItem.Delete(taskItem);
            _unitOfWork.Save();
        }

        public TaskEntity Get(Expression<Func<TaskEntity, bool>>? filter, string? includeProperties = null)
        {
            var taskItem = _unitOfWork.TaskItem.Get(filter, includeProperties);
            if (taskItem == null)
            {
                throw new Exception("Task not found.");
            }
            return taskItem;
        }

        public IEnumerable<TaskEntity> GetAll(string? includeProperties = null)
        {
            var taskItems = _unitOfWork.TaskItem.GetAll(includeProperties);
            return taskItems;
        }

        public void Update(TaskDTO taskDTO)
        {
            var taskItem = _unitOfWork.TaskItem.Get(t => t.Id == taskDTO.Id);
            if (taskItem == null)
            {
                throw new Exception("Task not found.");
            }
            taskItem.Title = taskDTO.Title;
            taskItem.Description = taskDTO.Description;
            taskItem.DueDate = taskDTO.DueDate;
            taskItem.Priority = taskDTO.Priority;
            taskItem.CategoryId = taskDTO.CategoryId;
            _unitOfWork.TaskItem.Update(taskItem);
            _unitOfWork.Save();
        }
    }
}
