namespace MyTaskManager.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ITaskRepository TaskItem { get; }
        void Save();
    }
}
