
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TinyCmsTrainer.Models;

namespace TinyCmsTrainer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Page> Pages { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }

        public DbSet<ScheduledPost> ScheduledPosts { get; set; }
    }
}
