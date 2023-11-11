using Commercial.Application.DTOs.Stock;
using Commercial.Domain.Commons;

namespace Commercial.Application.Services.Interfaces;

public interface IStockService
{
    ValueTask<Response<StockDTO>> CreateStockAsync(CreateStock stock);
    ValueTask<Response<StockDTO>> EditStockAsync(StockDTO stock);
    ValueTask<Response<StockDTO>> RemoveAsync(Guid stockId);
    ValueTask<Response<IReadOnlyCollection<StockDTO>>> GetAllAsync();
    ValueTask<Response<IReadOnlyCollection<StockDTO>>> GetByProductAsync(Guid productId);
    ValueTask<Response<StockDTO>> GetByIdAsync(Guid stockId);
}