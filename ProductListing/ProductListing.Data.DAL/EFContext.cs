using Microsoft.EntityFrameworkCore;
using ProductListing.Data.Domain;

namespace ProductListing.Data.DAL
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Göz Kalemi",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "Göz Kalemi",
                Details = "Çok güzel bir göz kalemi."
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
