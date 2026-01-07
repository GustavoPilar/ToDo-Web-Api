namespace ToDo.BackEnd
{
    public interface IUnitOfWork
    {
        ISeverityRepository SeverityRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IToDoRepository ToDoRepository { get; }
        void Commit();

    }
}
