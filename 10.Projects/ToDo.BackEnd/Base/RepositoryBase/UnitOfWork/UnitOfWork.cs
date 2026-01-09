using System.Collections.Concurrent;

namespace ToDo.BackEnd
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ToDoContext _context;

        private readonly ConcurrentDictionary<Type, object> repositories = new();

        public UnitOfWork(ToDoContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : class, IEntityBase
        {
            return (IRepositoryBase<TEntity>)repositories.GetOrAdd(
                typeof(TEntity),
                _ => new RepositoryBase<TEntity>(_context)
            );
        }
    }
}
