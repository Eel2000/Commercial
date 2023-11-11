using Commercial.Application.DTOs.Stock;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using MediatR;

namespace Commercial.Application.Features.Stock.Queries;

public class GetByProductQuery : IRequest<Response<IReadOnlyCollection<StockDTO>>>
{
    public GetByProductQuery(Guid productId)
    {
        ProductId = productId;
    }

    public Guid ProductId { get; set; }
}

public class GetByProductQueryHandler : IRequestHandler<GetByProductQuery, Response<IReadOnlyCollection<StockDTO>>>
{
    private readonly IStockService _stockService;

    public GetByProductQueryHandler(IStockService stockService)
    {
        _stockService = stockService;
    }

    public async Task<Response<IReadOnlyCollection<StockDTO>>> Handle(GetByProductQuery request, CancellationToken cancellationToken)
    {
        return await _stockService.GetByProductAsync(request.ProductId);
    }
}