using Commercial.Application.DTOs.Product;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using MediatR;

namespace Commercial.Application.Features.Product.Queries;

public class GetAvailableProductPerCategoryQuery : IRequest<Response<IReadOnlyCollection<GetProduct>>>
{
    public int Page { get; set; }
    public int Count { get; set; }
    public Guid Category { get; set; }

    public GetAvailableProductPerCategoryQuery(int page, int count, Guid category)
    {
        Page = page;
        Count = count;
        Category = category;
    }
}

public class GetAvailableProductPerCategoryQueryHandler : IRequestHandler<GetAvailableProductPerCategoryQuery,
    Response<IReadOnlyCollection<GetProduct>>>
{
    private readonly IProductService _productService;

    public GetAvailableProductPerCategoryQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Response<IReadOnlyCollection<GetProduct>>> Handle(GetAvailableProductPerCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetAvailableProductListPerCategoryAsync(request.Page, request.Count,
            request.Category);
    }
}