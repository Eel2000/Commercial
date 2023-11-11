using Commercial.Application.DTOs.Stock;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using FluentValidation;
using MediatR;

namespace Commercial.Application.Features.Stock.Commands;

public class CreateCommand : IRequest<Response<StockDTO>>
{
    public CreateCommand(CreateStock stock)
    {
        Stock = stock;
    }

    public CreateStock Stock { get; set; }
}

public class CreatedCommandHandler : IRequestHandler<CreateCommand, Response<StockDTO>>
{
    private readonly IValidator<CreateStock> _validator;
    private readonly IStockService _stockService;

    public CreatedCommandHandler(IStockService stockService, IValidator<CreateStock> validator)
    {
        _stockService = stockService;
        _validator = validator;
    }

    public async Task<Response<StockDTO>> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request.Stock);
        if (validation.IsValid)
            return await _stockService.CreateStockAsync(request.Stock);

        var errors = validation.Errors.Select(x => x.ErrorMessage).ToArray();

        return new Response<StockDTO>("An Error occured while processing", errors);
    }
}