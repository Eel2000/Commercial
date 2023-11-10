using Commercial.Application.DTOs.Product;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using MediatR;

namespace Commercial.Application.Features.Product.Queries;

public class GetAvailableProductQuery : IRequest<Response<IReadOnlyCollection<GetProduct>>>
{
    public int Page { get; set; }
    public int Count { get; set; }

    public GetAvailableProductQuery(int page, int count)
    {
        Page = page;
        Count = count;
    }
}

public class
    GetAvailableProductQueryHandler : IRequestHandler<GetAvailableProductQuery,
        Response<IReadOnlyCollection<GetProduct>>>
{
    private readonly IProductService _productService;

    public GetAvailableProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Response<IReadOnlyCollection<GetProduct>>> Handle(GetAvailableProductQuery request,
        CancellationToken cancellationToken)
    {
        return await _productService.GetAvailableProductListAsync(request.Page, request.Count);
    }
}