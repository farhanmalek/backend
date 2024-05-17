
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Configure the relationships between the tables
            builder.Entity<Chat>()
                .HasOne<User>()
                .WithMany(u => u.Chats)
                .HasForeignKey(c => c.User1Id);

            builder.Entity<Chat>()
                .HasOne<User>()
                .WithMany(u => u.Chats)
                .HasForeignKey(c => c.User2Id);

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

            builder.Entity<Message>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(f => f.ReceiverId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.SenderId)
                .OnDelete(DeleteBehavior.NoAction);




            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole{Name = "User", NormalizedName = "USER"}
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}