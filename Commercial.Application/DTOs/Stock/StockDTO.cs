namespace Commercial.Application.DTOs.Stock;

public class StockDTO
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdate { get; set; }
    public string? Name { get; set; }
    public Guid ProductId { get; set; }
    public long Quantity { get; set; }
    public bool IsSoldOut() => Quantity <= 0;
}