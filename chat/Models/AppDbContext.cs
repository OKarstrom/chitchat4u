using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Message> Message { get; set; }
        public DbSet<Connection> Connection { get; set; }
        public DbSet<ApplicationUserConnection> UserConnections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserConnection>()
               .HasKey(a => new { a.ConnectionID, a.ApplicationUserID });
           

            base.OnModelCreating(modelBuilder);
        }


    }
}
