namespace Commercial.Application.DTOs.Stock;

public record CreateStock(string? Name, Guid ProductId, long Quantity);