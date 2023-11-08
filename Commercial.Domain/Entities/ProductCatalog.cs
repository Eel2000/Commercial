using Commercial.Domain.Commons;

namespace Commercial.Domain.Entities;

public class ProductCatalog : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid CatalogId { get; set; }

    public virtual Product Product { get; set; }
    public virtual Catalog Catalog { get; set; }
}