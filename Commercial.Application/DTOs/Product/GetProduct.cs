namespace Commercial.Application.DTOs.Product;

public class GetProduct
{

    public GetProduct()
    {
        Pics = new HashSet<string>();
    }
    
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? CoverPic { get; set; }
    public bool IsAvailable { get; set; }
    public decimal UnitPrice { get; set; }
    
    public virtual ICollection<string> Pics { get; set; }
}