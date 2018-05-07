using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Models
{
    public class MyWebApiContext : DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options) { }

        public DbSet<Bug> bugs { get; set; }
    }
}