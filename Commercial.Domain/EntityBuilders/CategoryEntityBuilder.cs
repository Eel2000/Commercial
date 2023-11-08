using Commercial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commercial.Domain.EntityBuilders;

public static class CategoryEntityBuilder
{
    public static void SetupCategory(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasKey(c => c.Id);

        modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();

        modelBuilder.Entity<Category>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .IsRequired();

        modelBuilder.Entity<Category>()
            .Property(c => c.Description);

        modelBuilder.Entity<Category>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Category>()
            .Property(c => c.LastUpdate)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnUpdate();

        modelBuilder.Entity<Category>()
            .Property(c => c.CreatedBy)
            .IsRequired();

        modelBuilder.Entity<Category>()
            .Property(c => c.UpdateBy);

        modelBuilder.Entity<Category>()
            .Property(c => c.IsActive)
            .HasDefaultValue(true);
    }
}