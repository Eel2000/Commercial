using Commercial.Application.DTOs.Product;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using FluentValidation;
using MediatR;

namespace Commercial.Application.Features.Product.Commands;

public class CreateCommand : IRequest<Response<GetProduct>>
{
    public CreateProduct Product { get; set; }

    public CreateCommand(CreateProduct product)
    {
        Product = product;
    }
}

public class CreateCommandHandler : IRequestHandler<CreateCommand, Response<GetProduct>>
{
    private readonly IValidator<CreateProduct> _validator;
    private readonly IProductService _productService;

    public CreateCommandHandler(IValidator<CreateProduct> validator, IProductService productService)
    {
        _validator = validator;
        _productService = productService;
    }

    public async Task<Response<GetProduct>> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request.Product);
        if (validation.IsValid)
            return await _productService.CreateAsync(request.Product);

        var errors = validation.Errors.Select(x => x.ErrorMessage).ToArray();

        return new Response<GetProduct>("Failed to save the product", errors);
    }
}