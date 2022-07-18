using Helmes.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelmesWebAPI.Entities
{
    public class HelmesContext : DbContext
    {
        public HelmesContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sector>()
               .HasKey(e => new { e.ID});

            modelBuilder.Seed();
        }
    }
}
