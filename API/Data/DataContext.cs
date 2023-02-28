using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // Represets tables
        public DbSet<AppUser> Users { get; set; }
        // Do not need to add here the photo db set beacuse it is implicit from 
        // the AppUser class
        public DbSet<UserLike> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // call the superclass method
            base.OnModelCreating(builder);

            // Set primary key
            builder.Entity<UserLike>()
                .HasKey(k => new {k.SourceUserId, k.TargetUserId});

            // Set relationschips
            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser) // say lisa
                .WithMany(d => d.LikedUsers) // may like many other users
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserLike>()
                .HasOne(s => s.TargetUser) // say bob
                .WithMany(d => d.LikedByUsers) // may be liked by many users
                .HasForeignKey(s => s.TargetUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}