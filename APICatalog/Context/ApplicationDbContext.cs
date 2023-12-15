using APICatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)"); 
        }
    }


}
