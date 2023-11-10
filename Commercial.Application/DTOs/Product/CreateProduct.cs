namespace Commercial.Application.DTOs.Product;

public record CreateProduct(string Name, string Description, string CoverPic, bool IsAvailable, decimal UnitPrice,
    HashSet<string> Pics, Guid CategoryId);