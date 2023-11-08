using Commercial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commercial.Domain.EntityBuilders;

public static class ProductCatalogEntityBuilder
{
    public static void SetupProductCatalog(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCatalog>().HasKey(pc => pc.Id);


        modelBuilder.Entity<ProductCatalog>()
            .Property(pc => pc.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<ProductCatalog>()
            .Property(pc => pc.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ProductCatalog>()
            .Property(pc => pc.LastUpdate)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnUpdate();

        modelBuilder.Entity<ProductCatalog>()
            .Property(pc => pc.CreatedBy)
            .IsRequired();

        modelBuilder.Entity<ProductCatalog>()
            .Property(pc => pc.UpdateBy);

        modelBuilder.Entity<ProductCatalog>()
            .Property(pc => pc.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<ProductCatalog>()
            .HasOne<Product>(pc => pc.Product)
            .WithMany(p => p.ProductCatalogs)
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<ProductCatalog>()
            .HasOne<Catalog>(pc => pc.Catalog)
            .WithMany(c => c.ProductCatalogs)
            .HasForeignKey(pc => pc.CatalogId);
    }
}