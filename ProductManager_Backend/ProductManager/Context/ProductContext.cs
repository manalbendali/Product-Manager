using Microsoft.EntityFrameworkCore;
using ProductManager.Models;

namespace ProductManager.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

    }
}
