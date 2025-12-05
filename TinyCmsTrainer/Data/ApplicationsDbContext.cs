using Microsoft.EntityFrameworkCore;
using TinyCmsTrainer.Models;

namespace TinyCmsTrainer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ContactMessage> Contacts { get; set; }
        public DbSet<MediaItem> MediaLibrary { get; set; }
        public DbSet<ScheduledPost> ScheduledPosts { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // RoleName kell, nem Name!
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "Editor" },
                new Role { Id = 3, RoleName = "Author" }
            );
        }
    }
}
