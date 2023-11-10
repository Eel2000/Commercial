using Commercial.Application.DTOs.Product;
using Commercial.Domain.Commons;

namespace Commercial.Application.Services.Interfaces;

public interface IProductService
{
    ValueTask<Response<GetProduct>> CreateAsync(CreateProduct product);
    ValueTask<Response<IReadOnlyCollection<GetProduct>>> GetAvailableProductListAsync(int page, int count);
    ValueTask<Response<GetProduct>> EditAsync(GetProduct product);
    ValueTask<Response<GetProduct>> RemoveAsync(Guid id);
}