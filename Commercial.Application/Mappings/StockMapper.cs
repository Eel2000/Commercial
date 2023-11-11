using Commercial.Application.DTOs.Stock;
using Commercial.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Commercial.Application.Mappings;

[Mapper]
public partial class StockMapper
{
    public partial StockDTO StockTOStockDTO(Stock stock);
    
    public partial IReadOnlyCollection<StockDTO> StockTOStockDTO(IReadOnlyCollection<Stock> stocks);
    
    public partial Stock StockDtoToStock(StockDTO stockDto);

    public partial Stock CreateStockDtoToStock(CreateStock createStock);
}