namespace MyTaskManager.Repository.IRepository
{
    public interface IUnitOfWorkAsync
    {

        public ITaskRepositoryAsync TaskItem { get; }
        void Save();

    }
}
