namespace ToDo.BackEnd
{
    public interface IToDoRepository : IRepositoryBase<ToDo>
    {
        IEnumerable<ToDo> GetAllByCategory(int categoryId);
    }
}
