namespace ToDo.BackEnd
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISeverityRepository _severityRepository;

        private ICategoryRepository _categoryRepository;

        private IToDoRepository _toDoRepository;

        public ToDoContext _context;

        public UnitOfWork(ToDoContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
            }
        }

        public ISeverityRepository SeverityRepository
        {
            get
            {
                return _severityRepository = _severityRepository ?? new SeverityRepository(_context);
            }
        }

        public IToDoRepository ToDoRepository
        {
            get
            {
                return _toDoRepository = _toDoRepository ?? new ToDoRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
