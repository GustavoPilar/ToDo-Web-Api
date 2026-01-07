namespace ToDo.BackEnd
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Category? GetById(int id);
    }
}
