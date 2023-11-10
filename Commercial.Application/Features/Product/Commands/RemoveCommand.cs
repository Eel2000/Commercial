using Commercial.Application.DTOs.Product;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using MediatR;

namespace Commercial.Application.Features.Product.Commands;

public class RemoveCommand : IRequest<Response<GetProduct>>
{
    public RemoveCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class RemoveCommandHandler : IRequestHandler<RemoveCommand, Response<GetProduct>>
{
    private readonly IProductService _productService;

    public RemoveCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Response<GetProduct>> Handle(RemoveCommand request, CancellationToken cancellationToken)
    {
        return await _productService.RemoveAsync(request.Id);
    }
}