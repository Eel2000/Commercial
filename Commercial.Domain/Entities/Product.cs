using Commercial.Domain.Commons;

namespace Commercial.Domain.Entities;

public class Product : BaseEntity
{
    public Product()
    {
        Pics = new HashSet<string>();
        ProductCatalogs = new HashSet<ProductCatalog>();
    }
    
    
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CoverPic { get; set; }
    public bool IsAvailable { get; set; }
    public decimal UnitPrice { get; set; }
    
    public virtual ICollection<string> Pics { get; set; }

    public virtual Category Category { get; set; }
    
    public virtual ICollection<ProductCatalog> ProductCatalogs { get; set; }
}