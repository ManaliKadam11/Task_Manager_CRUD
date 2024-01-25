using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<TaskManager> TaskManagers => Set<TaskManager>();
    }
}
