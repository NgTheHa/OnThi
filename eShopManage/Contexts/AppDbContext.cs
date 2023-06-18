using eShopManage.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShopManage.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ShopProvider> ShopProviders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Shop>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique(true);
            });
            builder.Entity<Provider>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique(true);
            });
            builder.Entity<ShopProvider>(entity =>
            {
                entity.HasKey(x => x.Id);
            });
            builder.Entity<Shop>().HasMany(shop => shop.Provider)
                                    .WithMany(provider => provider.Shops)
                                    .UsingEntity<ShopProvider>(l => l.HasOne(c => c.Provider)
                                                                     .WithMany(e => e.ShopProviders)
                                                                     .HasForeignKey(e => e.IdProvider),
                                                               r => r.HasOne(c => c.Shop)
                                                                     .WithMany(e => e.ShopProviders)
                                                                     .HasForeignKey(e => e.IdShop));
        }
    }
}
