
namespace ToDo.BackEnd
{
    public class ToDoRepository : RepositoryBase<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }

        public ToDo? GetById(int id)
        {
            return _context.ToDos.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<ToDo> GetAllByCategory(int categoryId)
        {
            return _context.ToDos.Where(x => x.CategoryId == categoryId);
        }
    }
}
