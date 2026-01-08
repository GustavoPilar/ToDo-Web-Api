namespace ToDo.BackEnd
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ToDoContext context) : base(context)
        {
        }
    }
}
