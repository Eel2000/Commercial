using Commercial.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api_endpoints.Middlewares;

public class GlobalExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            string[] errors = { e.Message, e?.InnerException?.Message };
            if (e is DbUpdateException updateException)
            {
                errors = new[] { string.Join("\n\r", updateException.Entries), updateException.Message };
            }
            else if (e is DbUpdateConcurrencyException updateConcurrencyException)
            {              
                errors = new[] { string.Join("\n\r", updateConcurrencyException.Entries), updateConcurrencyException.Message };
            }

            var res = new Response<Exception>("An Error occured while processing", errors);
            var json = JsonConvert.SerializeObject(res);

            var response = context.Response;
            if (!response.HasStarted)
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.ContentType = "application/json";
                await response.WriteAsync(json);
            }
        }
    }
}