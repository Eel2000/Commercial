using System.ComponentModel.DataAnnotations;
using Asp.Versioning.Conventions;
using Carter;
using Commercial.Application.DTOs.Product;
using Commercial.Application.Features.Product.Commands;
using Commercial.Application.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api_endpoints.Routes;

public class ProductModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var version = app.NewApiVersionSet("Product")
            .HasApiVersion(1, 0)
            .HasApiVersion(2, 0)
            .ReportApiVersions()
            .Build();

        var baseRoot = app.MapGroup("api/product/v{version:apiVersion}")
            .WithApiVersionSet(version)
            .WithSummary("All api related to products");

        baseRoot.MapPost("create", HandleCreate).MapToApiVersion(1, 0);
        baseRoot.MapPut("edit", HandleEdit).MapToApiVersion(1, 0);
        baseRoot.MapDelete("remove", HandleRemove).MapToApiVersion(1, 0)
            .WithDescription("Where is the product unique identifier.");
        baseRoot.MapGet("available", HandleGetListOfAvailable).MapToApiVersion(1, 0).WithDescription(
            "get the list of all available product. Where p is the page and c the count of product per page");
    }

    async ValueTask<IResult> HandleCreate(IMediator mediator, [FromBody, Required] CreateProduct product)
    {
        var result = await mediator.Send(new CreateCommand(product));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }

    async ValueTask<IResult> HandleEdit(IMediator mediator, [FromBody, Required] GetProduct product)
    {
        var result = await mediator.Send(new EditCommand(product));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }

    async ValueTask<IResult> HandleRemove(IMediator mediator, Guid p)
    {
        var result = await mediator.Send(new RemoveCommand(p));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }

    async ValueTask<IResult> HandleGetListOfAvailable(IMediator mediator, [FromQuery, Required] int p,
        [FromQuery, Required] int c)
    {
        var result = await mediator.Send(new GetAvailableProductQuery(p, c));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.NotFound(result);
    }
}