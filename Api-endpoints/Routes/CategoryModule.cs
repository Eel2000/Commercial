using Carter;
using Commercial.Application.DTOs.Category;
using Commercial.Application.Features.Category.Commands;
using Commercial.Application.Features.Category.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api_endpoints.Routes;

public class CategoryModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var version = app.NewVersionedApi("Category-v1");

        var baseRoot = version.MapGroup("Categories");

        baseRoot.MapGet("/list", HandleGetCategories).HasApiVersion(1.0);

        baseRoot.MapPost("create-new", HandleCreateCategory).HasApiVersion(1.0);
    }

    async ValueTask<IResult> HandleGetCategories(IMediator mediator)
    {
        var result = await mediator.Send(new GetCategoriesQueries());
        return Results.Ok(result);
    }

    async ValueTask<IResult> HandleCreateCategory(IMediator mediator, [FromBody] CreateCategoryDTO category)
    {
        var result = await mediator.Send(new CreateCategoryCommand(category));

        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }
}