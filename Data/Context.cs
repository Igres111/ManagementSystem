using ManagmentSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagmentSystemApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(entity => entity.Id);
            });
        }
        }
}
