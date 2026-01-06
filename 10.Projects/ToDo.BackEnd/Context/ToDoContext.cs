using Microsoft.EntityFrameworkCore;

namespace ToDo.BackEnd
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options) : base(options)
        {
        }

        protected ToDoContext()
        {
        }

        public DbSet<Severity> Severities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
