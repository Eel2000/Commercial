using System.Collections.Immutable;
using Commercial.Application.DTOs.Category;
using Commercial.Application.Services.Interfaces;
using Commercial.Domain.Commons;
using MediatR;

namespace Commercial.Application.Features.Category.Queries;

public class GetCategoriesQueries : IRequest<Response<ImmutableList<CategoryDTO>>>
{
}

public class GetCategoriesQueriesHandler : IRequestHandler<GetCategoriesQueries, Response<ImmutableList<CategoryDTO>>>
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesQueriesHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Response<ImmutableList<CategoryDTO>>> Handle(GetCategoriesQueries request,
        CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetCategoriesAsync();

        return result;
    }
}