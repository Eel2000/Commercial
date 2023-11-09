using Api_endpoints.Middlewares;

namespace Api_endpoints.Extensions;

public static class Middleware
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandler>();

        return app;
    }
}