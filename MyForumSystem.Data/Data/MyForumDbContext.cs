using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyForumSystem.Data.Models;

namespace MyForumSystem.Data
{
    public class MyForumDbContext : IdentityDbContext
    {
        public MyForumDbContext(DbContextOptions<MyForumDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Post { get; set; }
        public DbSet<Comment>? Comments { get; set; }
    }
}