using Microsoft.EntityFrameworkCore;
using XeynergyUser.API.Models;

namespace XeynergyUser.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<AccessRule> AccessRule { get; set; }

        public DbSet<UserGroup> UserGroup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
            .HasMany<User>(g => g.Users)
            .WithOne(s => s.UserGroup)
            .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<AccessRule>()
            .HasMany<UserGroup>(g => g.UserGroups)
            .WithOne(s => s.AccessRule)
            .HasForeignKey(s => s.RuleId);

        }
    }
}
