using Commercial.Application.DTOs.Stock;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using MediatR;

namespace Commercial.Application.Features.Stock.Queries;

public class GetByIdQuery : IRequest<Response<StockDTO>>
{
    public GetByIdQuery(Guid stockId)
    {
        StockId = stockId;
    }

    public Guid StockId { get; set; }
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<StockDTO>>
{
    private readonly IStockService _stockService;

    public GetByIdQueryHandler(IStockService stockService)
    {
        _stockService = stockService;
    }

    public async Task<Response<StockDTO>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _stockService.GetByIdAsync(request.StockId);
    }
}