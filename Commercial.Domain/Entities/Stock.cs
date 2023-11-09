using Commercial.Domain.Commons;

namespace Commercial.Domain.Entities;

public class Stock : BaseEntity
{
    public string? Name { get; set; }
    public Guid ProductId { get; set; }
    public long Quantity { get; set; }

    /// <summary>
    /// Checks if the current product is sold out for the current stock
    /// </summary>
    /// <returns><see cref="bool"/> true is it's sold out otherwise false.</returns>
    public bool IsSoldOut() => Quantity <= 0;
    
    public Product? Product { get; set; }
}