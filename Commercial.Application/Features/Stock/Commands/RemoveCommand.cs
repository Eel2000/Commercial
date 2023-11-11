using Commercial.Application.DTOs.Stock;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using MediatR;

namespace Commercial.Application.Features.Stock.Commands;

public class RemoveCommand : IRequest<Response<StockDTO>>
{
    public RemoveCommand(Guid stockId)
    {
        StockId = stockId;
    }

    public Guid StockId { get; set; }
}

public class RemoveCommandHandler : IRequestHandler<RemoveCommand, Response<StockDTO>>
{
    private readonly IStockService _stockService;

    public RemoveCommandHandler(IStockService stockService)
    {
        _stockService = stockService;
    }

    public async Task<Response<StockDTO>> Handle(RemoveCommand request, CancellationToken cancellationToken)
    {
        return await _stockService.RemoveAsync(request.StockId);
    }
}