using Commercial.Application.DTOs.Stock;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using MediatR;

namespace Commercial.Application.Features.Stock.Queries;

public class GetAllQuery : IRequest<Response<IReadOnlyCollection<StockDTO>>>
{
    public int Page { get; set; }
    public int Count { get; set; }

    public GetAllQuery(int page, int count)
    {
        Page = page;
        Count = count;
    }
}

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Response<IReadOnlyCollection<StockDTO>>>
{
    private readonly IStockService _stockService;

    public GetAllQueryHandler(IStockService stockService)
    {
        _stockService = stockService;
    }

    public async Task<Response<IReadOnlyCollection<StockDTO>>> Handle(GetAllQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _stockService.GetAllAsync(request.Page, request.Count);
        return result;
    }
}