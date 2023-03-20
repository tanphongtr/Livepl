using Microsoft.EntityFrameworkCore;
using livepl.Entities;

namespace livepl.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("Filename=./ApiDb.db");

            // write code using the optionsBuilder to configure the database using mysql

            optionsBuilder.UseMySql("server=localhost;database=livepl2;user=root;password=amBc7juC;port=4612", new MySqlServerVersion(new Version(8, 0, 25)));
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
