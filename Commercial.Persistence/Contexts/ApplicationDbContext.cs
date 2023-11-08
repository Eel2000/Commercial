using Commercial.Domain.Entities;
using Commercial.Domain.EntityBuilders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Commercial.Persistence.Contexts;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.SetupCatalog();
        builder.SetupProduct();
        builder.SetupProductCatalog();
        builder.SetupStock();
        builder.SetupCategory();

        base.OnModelCreating(builder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCatalog> ProductCatalogs { get; set; }
}