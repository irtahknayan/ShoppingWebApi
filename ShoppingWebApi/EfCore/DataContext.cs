using Microsoft.EntityFrameworkCore;

namespace ShoppingWebApi.EfCore
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        
        //public override void OnModelcreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.UseSerialColumns();
        //}
        
        public DbSet<Product> Products { get; set;}
        public DbSet<Order> Orders { get; set; }

    }
}
