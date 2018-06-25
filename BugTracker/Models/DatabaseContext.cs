using System;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}
        public DbSet<Bug> Bugs { get; set; }

		public void ListAsync()
		{
			throw new NotImplementedException();
		}
	}
}