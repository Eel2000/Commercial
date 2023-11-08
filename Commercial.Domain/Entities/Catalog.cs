using Commercial.Domain.Commons;

namespace Commercial.Domain.Entities;

public class Catalog : BaseEntity
{
    public Catalog()
    {
        ProductCatalogs = new HashSet<ProductCatalog>();
    }
    
    public string Name { get; set; }
    
    public virtual ICollection<ProductCatalog> ProductCatalogs { get; set; }
}