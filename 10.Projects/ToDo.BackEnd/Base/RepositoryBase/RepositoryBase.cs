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
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public virtual T? GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => (int)(x.GetType().GetProperty("Id").GetValue(x)) == id);
        }

        public IEnumerable<T> GetAllByProp(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsNoTracking().ToList();
        }
        public T? GetByProp(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        #endregion
    }
}
