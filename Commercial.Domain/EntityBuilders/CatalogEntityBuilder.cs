using Commercial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commercial.Domain.EntityBuilders;

public static class CatalogEntityBuilder
{
    public static void SetupCatalog(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catalog>().HasKey(c => c.Id);

        modelBuilder.Entity<Catalog>()
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder.Entity<Catalog>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Catalog>()
            .Property(c => c.Name)
            .IsRequired();

        modelBuilder.Entity<Catalog>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Catalog>()
            .Property(c => c.LastUpdate)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnUpdate();

        modelBuilder.Entity<Catalog>()
            .Property(c => c.CreatedBy)
            .IsRequired();

        modelBuilder.Entity<Catalog>()
            .Property(c => c.UpdateBy);

        modelBuilder.Entity<Catalog>()
            .Property(c => c.IsActive)
            .HasDefaultValue(true);
    }
}