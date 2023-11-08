using Commercial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Commercial.Domain.EntityBuilders;

public static class StockEntityBuilder
{
    public static void SetupStock(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>().HasKey(s => s.Id);

        modelBuilder.Entity<Stock>().HasIndex(s => s.Name).IsUnique();

        modelBuilder.Entity<Stock>().Property(s => s.Id).ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Stock>()
            .Property(s => s.ProductId)
            .IsRequired();

        modelBuilder.Entity<Stock>()
            .Property(s => s.Quantity)
            .IsRequired();
        
        modelBuilder.Entity<Stock>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Stock>()
            .Property(s => s.LastUpdate)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnUpdate();

        modelBuilder.Entity<Stock>()
            .Property(s => s.CreatedBy)
            .IsRequired();

        modelBuilder.Entity<Stock>()
            .Property(s => s.UpdateBy);

        modelBuilder.Entity<Stock>()
            .Property(s => s.IsActive)
            .HasDefaultValue(true);
    }
}