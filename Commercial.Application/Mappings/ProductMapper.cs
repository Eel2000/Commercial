using Commercial.Application.DTOs.Product;
using Commercial.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Commercial.Application.Mappings;

[Mapper]
public partial class ProductMapper
{
    public partial Product CreateProductDtoToProduct(CreateProduct product);

    public partial GetProduct ProductToProductDTO(Product product);
    
    public partial IReadOnlyCollection<GetProduct> ProductToProductDTO(IReadOnlyCollection<Product> product);

    public partial Product GetProductDtoToProduct(GetProduct product);
}