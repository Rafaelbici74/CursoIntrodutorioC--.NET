using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entites;

namespace ProductClientHub.API.Infrastructure
{
    public class ProductsClientHubDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\MR- INFO\\Downloads\\ProductsClientHubDb.db");
        }
    }
}
