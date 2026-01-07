using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ToDo.BackEnd
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        #region Fields
        protected readonly ToDoContext _context;
        #endregion

        #region Constructor
        public RepositoryBase(ToDoContext context)
        {
            _context = context;
        }
        #endregion

        #region Members
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public IEnumerable<T> GetAllByProp(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
        public T? GetByProp(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }
        #endregion
    }
}
