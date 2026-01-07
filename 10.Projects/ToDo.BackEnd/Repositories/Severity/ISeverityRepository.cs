namespace ToDo.BackEnd
{
    public interface ISeverityRepository : IRepositoryBase<Severity>
    {
        Severity? GetById(int id);
    }
}
