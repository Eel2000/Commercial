using System.ComponentModel.DataAnnotations;
using Asp.Versioning.Conventions;
using Carter;
using Commercial.Application.DTOs.Stock;
using Commercial.Application.Features.Stock.Commands;
using Commercial.Application.Features.Stock.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api_endpoints.Routes;

public class StockModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var version = app.NewApiVersionSet("stock")
            .HasApiVersion(1, 0)
            .HasApiVersion(2, 0)
            .ReportApiVersions()
            .Build();

        var baseRoot = app.MapGroup("api/stock/v{version:apiVersion}")
            .WithApiVersionSet(version)
            .WithSummary("All api related to stock");

        baseRoot.MapPost("create-new", HandleCreateStock).MapToApiVersion(1, 0);
        baseRoot.MapPut("edit", HandleEditStock).MapToApiVersion(1, 0);
        baseRoot.MapDelete("remove", HandleRemoveStock).MapToApiVersion(1, 0);
        baseRoot.MapGet("all", HandleGetAllStocks).MapToApiVersion(1, 0);
        baseRoot.MapGet("list-by-product", HandleGetStocksByProduct).MapToApiVersion(1, 0);
        baseRoot.MapGet("by-id", HandleGetStockById).MapToApiVersion(1, 0);
    }

    async ValueTask<IResult> HandleCreateStock(IMediator mediator, [FromBody, Required] CreateStock stock)
    {
        var result = await mediator.Send(new CreateCommand(stock));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }

    async ValueTask<IResult> HandleEditStock(IMediator mediator, [FromBody, Required] StockDTO stock)
    {
        var result = await mediator.Send(new EditCommand(stock));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }

    async ValueTask<IResult> HandleRemoveStock(IMediator mediator, [FromQuery, Required] Guid i)
    {
        var result = await mediator.Send(new RemoveCommand(i));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }

    async ValueTask<IResult> HandleGetAllStocks(IMediator mediator, [FromQuery, Required] int p, int c)
    {
        var result = await mediator.Send(new GetAllQuery(p, c));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }

    async ValueTask<IResult> HandleGetStocksByProduct(IMediator mediator, [FromQuery, Required] Guid p)
    {
        var result = await mediator.Send(new GetByProductQuery(p));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }

    async ValueTask<IResult> HandleGetStockById(IMediator mediator, [FromQuery, Required] Guid s)
    {
        var result = await mediator.Send(new GetByIdQuery(s));
        if (result.Succeed)
            return Results.Ok(result);

        return Results.BadRequest(result);
    }
}