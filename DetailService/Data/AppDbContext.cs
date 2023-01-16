using DetailService.Models;
using Microsoft.EntityFrameworkCore;

namespace DetailService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Detail> Details { get; set; }
    }
}