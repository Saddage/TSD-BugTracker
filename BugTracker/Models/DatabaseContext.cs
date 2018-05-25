using Microsoft.EntityFrameworkCore;

namespace BugTracker.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}
        public DbSet<Project> projects { get; set; }
        public DbSet<Bug> bugs { get; set; }
    }
}