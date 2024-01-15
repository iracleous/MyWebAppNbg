using DomainProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainProject.Data
{
    public class EshopDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=(local);Initial Catalog=nbgEshopDb;User Id=sa; Password=passw0rd;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public EshopDbContext()
        {
        }

        public EshopDbContext(DbContextOptions<EshopDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(product => product.Price)
                .HasPrecision(12, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
