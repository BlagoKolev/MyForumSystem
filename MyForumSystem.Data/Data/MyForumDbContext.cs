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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>()
                .HasOne(x=>x.Creator)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(x=>x.Creator)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);                  
                
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Post { get; set; }
        public DbSet<Comment>? Comments { get; set; }
    }
}