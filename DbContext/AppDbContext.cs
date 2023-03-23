// gen code DbContext/AppDbContext.cs
using Livepl.Entities;
using Microsoft.EntityFrameworkCore;
// using DbContext


namespace Livepl.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=test15;user=root;password=amBc7juC;port=4612", new MySqlServerVersion(new System.Version(8, 0, 23)));
        }

        // async
        public DbSet<User> User { get; set; }
    }
}