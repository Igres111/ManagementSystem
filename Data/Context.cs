using ManagmentSystemApi.Models;
using ManagmentSystemApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ManagmentSystemApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectForUser> ProjectForUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(entity => entity.Id);
            });
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasOne(entity => entity.User)
                .WithMany(entity => entity.RefreshTokens)
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<ProjectForUser>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.HasOne(entity => entity.Project)
                .WithMany(entity => entity.ProjectForUser)
                .HasForeignKey(entity => entity.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(entity => entity.User)
               .WithMany(entity => entity.ProjectForUser)
               .HasForeignKey(entity => entity.UserId)
               .OnDelete(DeleteBehavior.Cascade);
            });
        }
        }
}
