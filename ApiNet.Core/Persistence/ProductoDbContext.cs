using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class ProductoDbContext : DbContext
    {
        public DbSet<Producto> Producto { get; set; }

        public ProductoDbContext(DbContextOptions<ProductoDbContext> options)
            : base(options)
        { }
    }
}
