namespace ToDo.BackEnd
{
    public class SeverityRepository : RepositoryBase<Severity>, ISeverityRepository
    {
        public SeverityRepository(ToDoContext context) : base(context)
        {
        }
    }
}
