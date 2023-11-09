using Api_endpoints.Extensions;
using Api_endpoints.Middlewares;
using Api_endpoints.OpenApi;
using Asp.Versioning;
using Asp.Versioning.Conventions;
using Carter;
using Commercial.Application.Extensions;
using Commercial.Persistence.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(options => { options.GroupNameFormat = "'v'VVV"; });

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(AssemblyExtension.GetApplicationLibrayAssembly());
});

builder.Services.AddScoped<GlobalExceptionHandler>();

builder.Services.AddCarter();

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();


app.MapCarter();

app.UseSwaggerDocumentation();

app.UseGlobalExceptionHandler();

app.Run();
