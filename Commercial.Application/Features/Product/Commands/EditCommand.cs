using Commercial.Application.DTOs.Product;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using FluentValidation;
using MediatR;

namespace Commercial.Application.Features.Product.Commands;

public class EditCommand : IRequest<Response<GetProduct>>
{
    public EditCommand(GetProduct product)
    {
        Product = product;
    }

    public GetProduct Product { get; set; }
}

public class EditCommandHandler : IRequestHandler<EditCommand, Response<GetProduct>>
{
    private readonly IValidator<GetProduct> _validator;
    private readonly IProductService _productService;


    public EditCommandHandler(IValidator<GetProduct> validator, IProductService productService)
    {
        _validator = validator;
        _productService = productService;
    }

    public async Task<Response<GetProduct>> Handle(EditCommand request, CancellationToken cancellationToken)
    {
        var validation = await _validator.ValidateAsync(request.Product);
        if (validation.IsValid)
            return await _productService.EditAsync(request.Product);

        var errors = validation.Errors.Select(x => x.ErrorMessage).ToArray();

        return new Response<GetProduct>("Error while editing the product informations", errors);
    }
}