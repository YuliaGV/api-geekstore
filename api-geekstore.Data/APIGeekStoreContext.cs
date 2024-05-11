using api_geekstore.Shared;
using Microsoft.EntityFrameworkCore;

namespace api_geekstore.Data
{
    public class APIGeekStoreContext : DbContext
    {
        
        public APIGeekStoreContext(DbContextOptions options): base(options)
        {

        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }


    }
}
