namespace ToDo.BackEnd
{
    public class SeverityRepository : RepositoryBase<Severity>, ISeverityRepository
    {
        public SeverityRepository(ToDoContext context) : base(context)
        {
        }

        public Severity? GetById(int id)
        {
            return _context.Severities.FirstOrDefault(x => x.Id == id);
        }
    }
}
