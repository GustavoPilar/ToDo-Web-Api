using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ToDo.BackEnd
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase
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

        #region Get
        /// <summary>
        /// Retorna todos os registros
        /// </summary>
        /// <returns>IEnumerable</returns>
        public Pagination<T> GetAll(QueryStringPaginationParameter paginationParameter)
        {
            IQueryable<T> queryable = _context.Set<T>().AsNoTracking().AsQueryable<T>();
            return Pagination<T>.ToPagedList(queryable, paginationParameter.PageNumber, paginationParameter.PageSize);
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        #endregion

        #region Create
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        #endregion

        #region Update
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
        #endregion

        #region Delete
        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }
        #endregion
    }
}
