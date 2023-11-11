using Commercial.Application.DTOs.Stock;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using FluentValidation;
using MediatR;

namespace Commercial.Application.Features.Stock.Commands;

public class EditCommand : IRequest<Response<StockDTO>>
{
    public EditCommand(StockDTO stock)
    {
        Stock = stock;
    }

    public StockDTO Stock { get; set; }
}

public class EditCommandHandler : IRequestHandler<EditCommand, Response<StockDTO>>
{
    private readonly IValidator<StockDTO> _validator;
    private readonly IStockService _stockService;

    public EditCommandHandler(IValidator<StockDTO> validator, IStockService stockService)
    {
        _validator = validator;
        _stockService = stockService;
    }

    public async Task<Response<StockDTO>> Handle(EditCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request.Stock);
        if (validation.IsValid)
            return await _stockService.EditStockAsync(request.Stock);

        var errors = validation.Errors.Select(x => x.ErrorMessage).ToArray();

        return new Response<StockDTO>("An Error occured while processing", errors);
    }
}