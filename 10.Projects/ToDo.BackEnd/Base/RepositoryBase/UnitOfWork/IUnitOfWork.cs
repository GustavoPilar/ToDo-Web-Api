namespace ToDo.BackEnd
{
    public interface IUnitOfWork
    {
        ISeverityRepository SeverityRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IToDoRepository ToDoRepository { get; }
        IRepositoryBase<T> Repository<T>() where T : class;
        void Commit();

    }
}
