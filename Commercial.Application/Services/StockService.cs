using Commercial.Application.DTOs.Stock;
using Commercial.Application.Mappings;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using Commercial.Domain.Repositories.Interfaces;

namespace Commercial.Application.Services;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public async ValueTask<Response<StockDTO>> CreateStockAsync(CreateStock stock)
    {
        var mapper = new StockMapper();

        var newStock = mapper.CreateStockDtoToStock(stock);

        var creation = await _stockRepository.AddAsync(newStock);

        var created = mapper.StockTOStockDTO(creation);

        return new Response<StockDTO>("New stock added", created);
    }

    public async ValueTask<Response<StockDTO>> EditStockAsync(StockDTO stock)
    {
        var mapper = new StockMapper();

        var edition = mapper.StockDtoToStock(stock);

        var updateRaw = await _stockRepository.UpdateAsync(edition);

        var update = mapper.StockTOStockDTO(updateRaw);

        return new Response<StockDTO>("Stock updated", update);
    }

    public async ValueTask<Response<StockDTO>> RemoveAsync(Guid stockId)
    {
        var removedRaw = await _stockRepository.DeleteAsync(x => x.Id == stockId);

        var mapper = new StockMapper();

        return new Response<StockDTO>("stock removed", mapper.StockTOStockDTO(removedRaw));
    }

    public async ValueTask<Response<IReadOnlyCollection<StockDTO>>> GetAllAsync(int page, int count)
    {
        var raw = await _stockRepository.GetPagedResponseAsync(page, count, x => x.IsActive);

        var mapper = new StockMapper();

        return new Response<IReadOnlyCollection<StockDTO>>(mapper.StockTOStockDTO(raw));
    }

    public async ValueTask<Response<IReadOnlyCollection<StockDTO>>> GetByProductAsync(Guid productId)
    {
        var raw = await _stockRepository.ToListAsync(x => x.IsActive && x.ProductId == productId);

        var mapper = new StockMapper();

        return new Response<IReadOnlyCollection<StockDTO>>(mapper.StockTOStockDTO(raw));
    }

    public async ValueTask<Response<StockDTO>> GetByIdAsync(Guid stockId)
    {
        var raw = await _stockRepository.FirstOrDefaultAsync(x => x.Id == stockId);

        var mapper = new StockMapper();

        return new Response<StockDTO>(mapper.StockTOStockDTO(raw));
    }
}