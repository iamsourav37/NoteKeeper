using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteKeeper.Web.Models.Domain;
using NoteKeeper.Web.Models.Domain.Account;
using System.Reflection.Emit;

namespace NoteKeeper.Web.Models.Data
{
    public class ApplicationDBContext : IdentityDbContext<UserProfile, ApplicationRole, Guid>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<UserProfile>()
           .HasMany(u => u.Notes)
           .WithOne(n => n.UserProfile)
           .HasForeignKey(n => n.UserId);

        }
    }
}
