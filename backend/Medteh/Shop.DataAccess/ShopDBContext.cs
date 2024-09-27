using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Configuration;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            :base(options)
        {
            
        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SellerEntity> Sellers { get; set; }
        public DbSet<BuyerEntity> Buyers { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SellerConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
