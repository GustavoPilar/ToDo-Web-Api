namespace ToDo.BackEnd
{
    public interface IToDoRepository : IRepositoryBase<ToDo>
    {
        ToDo? GetById(int id);
        IEnumerable<ToDo> GetAllByCategory(int categoryId);
    }
}
