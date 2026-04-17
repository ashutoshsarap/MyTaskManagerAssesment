namespace MyTaskManager.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ITaskRepository TaskItem { get; }
        public ICategoryRepository Category { get; }
        void Save();
    }
}
