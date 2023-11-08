using Commercial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Commercial.Domain.EntityBuilders;

public static class ProductEntityBuilder
{
    public static void SetupProduct(this ModelBuilder modelBuilder)
    {
        var converter = new ValueConverter<ICollection<string>, string>
        (
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<ICollection<string>>(v) ?? new HashSet<string>()
        );

        var valueComparer = new ValueComparer<ICollection<string>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, value) => HashCode.Combine(a, value.GetHashCode())),
            c => c.ToList()
        );

        modelBuilder.Entity<Product>().HasKey(p => p.Id);

        modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();

        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.Description)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.CoverPic)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.IsAvailable);

        modelBuilder.Entity<Product>()
            .Property(p => p.UnitPrice)
            .HasPrecision(18, 6)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Product>()
            .Property(c => c.LastUpdate)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnUpdate();

        modelBuilder.Entity<Product>()
            .Property(c => c.CreatedBy)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(c => c.UpdateBy);

        modelBuilder.Entity<Product>()
            .Property(c => c.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<Product>()
            .Property(p => p.Pics)
            .HasConversion(converter)
            .Metadata.SetValueComparer(valueComparer);

        modelBuilder.Entity<Product>()
            .HasOne<Category>(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
    }
}