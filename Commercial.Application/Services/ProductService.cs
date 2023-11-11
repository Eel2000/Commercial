using Commercial.Application.DTOs.Product;
using Commercial.Application.Mappings;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using Commercial.Domain.Repositories.Interfaces;

namespace Commercial.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async ValueTask<Response<GetProduct>> CreateAsync(CreateProduct product)
    {
        var mapper = new ProductMapper();

        var newProduct = mapper.CreateProductDtoToProduct(product);

        var creation = await _productRepository.AddAsync(newProduct);

        return new Response<GetProduct>("Product created", mapper.ProductToProductDTO(creation));
    }

    public async ValueTask<Response<IReadOnlyCollection<GetProduct>>> GetAvailableProductListAsync(int page, int count)
    {
        var mapper = new ProductMapper();

        var productRaw = await _productRepository.GetPagedResponseAsync(page, count);

        var products = mapper.ProductToProductDTO(productRaw);

        return new Response<IReadOnlyCollection<GetProduct>>(products);
    }

    public async ValueTask<Response<IReadOnlyCollection<GetProduct>>> GetAvailableProductListPerCategoryAsync(int page,
        int count, Guid categoryId)
    {
        var mapper = new ProductMapper();

        var productRaw = await _productRepository.GetPagedResponseAsync(page, count, x => x.CategoryId == categoryId);

        var products = mapper.ProductToProductDTO(productRaw);

        return new Response<IReadOnlyCollection<GetProduct>>(products);
    }

    public async ValueTask<Response<GetProduct>> EditAsync(GetProduct product)
    {
        var mapper = new ProductMapper();

        var toEdit = mapper.GetProductDtoToProduct(product);

        var edition = await _productRepository.UpdateAsync(toEdit);

        var productEdited = mapper.ProductToProductDTO(edition);

        return new Response<GetProduct>("", productEdited);
    }

    public async ValueTask<Response<GetProduct>> RemoveAsync(Guid id)
    {
        var removedRaw = await _productRepository.DeleteAsync(p => p.Id == id);

        var mapper = new ProductMapper();

        var removed = mapper.ProductToProductDTO(removedRaw);

        return new Response<GetProduct>("Product deleted", removed);
    }
}