using Microsoft.EntityFrameworkCore;
using ProvidersService.Models;

namespace ProvidersService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Detail> Details {get; set;}
        public DbSet<Provider> Providers {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Detail>()
                .HasMany(p=> p.Provider)
                .WithOne(p=> p.Detail!)
                .HasForeignKey(p => p.DetailId);
            modelBuilder
                .Entity<Provider>()
                .HasOne(p => p.Detail)
                .WithMany(p => p.Provider)
                .HasForeignKey(p =>p.DetailId);
        }


    }
}