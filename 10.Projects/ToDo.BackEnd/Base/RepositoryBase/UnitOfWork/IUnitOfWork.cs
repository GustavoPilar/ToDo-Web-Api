namespace ToDo.BackEnd
{
    public interface IUnitOfWork
    {
        IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : class, IEntityBase;
        void Commit();

    }
}
