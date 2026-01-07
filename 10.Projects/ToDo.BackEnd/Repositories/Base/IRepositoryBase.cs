 using System.Linq.Expressions;

namespace ToDo.BackEnd
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllByProp(Expression<Func<T, bool>> predicate);
        T? GetByProp(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
