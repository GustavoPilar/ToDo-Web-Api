 using System.Linq.Expressions;

namespace ToDo.BackEnd
{
    public interface IRepositoryBase<T> where T : class, IEntityBase
    {
        #region Get
        Pagination<T> GetAll(QueryStringPaginationParameter paginationParameter);
        T? GetById(int id);
        #endregion

        #region Created
        T Create(T entity);
        #endregion

        #region Update
        T Update(T entity);
        #endregion

        #region Delete
        T Delete(T entity);
        #endregion
    }
}
