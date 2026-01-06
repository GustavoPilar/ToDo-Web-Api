namespace ToDo.BackEnd
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();
        Category GetCategoryById(int id);
        Category Create(Category category);
        Category Update(Category category);
        Category Delete(int id);
    }
}
