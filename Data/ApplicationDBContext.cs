
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        //insert the DbSet properties to create the tables in the database
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<UserChat> UserChats { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Configure the relationships between the tables
            builder.Entity<UserChat>()
            .HasKey(uc => new { uc.UserId, uc.ChatId });

            builder.Entity<UserChat>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserChats)
                .HasForeignKey(uc => uc.UserId);

            builder.Entity<UserChat>()
                .HasOne(uc => uc.Chat)
                .WithMany(c => c.UserChats)
                .HasForeignKey(uc => uc.ChatId);

            builder.Entity<Friendship>()
           .HasOne(f => f.User1)
           .WithMany(u => u.Friendships)
           .HasForeignKey(f => f.User1Id)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Friendship>()
                .HasOne(f => f.User2)
                .WithMany()
                .HasForeignKey(f => f.User2Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message>(entity =>
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Content)
              .IsRequired();

        entity.Property(e => e.SentAt)
              .IsRequired();

        entity.HasOne(e => e.Chat)
              .WithMany(c => c.Messages)
              .HasForeignKey(e => e.ChatId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(e => e.Messenger)
              .WithMany(u => u.Messages)
              .HasForeignKey(e => e.MessengerId)
              .OnDelete(DeleteBehavior.NoAction);
    });




            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole{Name = "User", NormalizedName = "USER"}
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}