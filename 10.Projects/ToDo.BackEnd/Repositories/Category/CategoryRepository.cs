
using Microsoft.EntityFrameworkCore;

namespace ToDo.BackEnd
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        readonly ToDoContext _context;
        #endregion

        #region Constructor
        public CategoryRepository(ToDoContext context)
        {
            _context = context;
        }
        #endregion

        #region Members
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }
        public Category Create(Category category)
        {
            if (category is null) 
                throw new ArgumentNullException(nameof(category));

            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public Category Update(Category category)
        {
            if (category is null)
                throw new ArgumentNullException(nameof(category));

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return category;
        }
        public Category Delete(int id)
        {
            Category category = _context.Categories.Find(id);

            if (category is null)
                throw new ArgumentNullException(nameof(category));

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return category;
        }
        #endregion
    }
}
