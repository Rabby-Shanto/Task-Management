using Microsoft.EntityFrameworkCore;
using Todo.Domain.EntityModel;

namespace Todo.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<TodoTask> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }

        
    }
}