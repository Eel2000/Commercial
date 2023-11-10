using Commercial.Application.DTOs.Category;
using Commercial.Application.DTOs.Product;
using Commercial.Application.Services;
using Commercial.Application.Services.Interfaces;
using Commercial.Application.Validators.Category;
using Commercial.Application.Validators.Product;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Commercial.Application.Extensions;

public static class Configuration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region Services

        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<IProductService, ProductService>();

        #endregion

        #region Validator

        services.AddScoped<IValidator<CreateCategoryDTO>, CategoryValidator>();
        services.AddScoped<IValidator<CategoryDTO>, EditCategoryValidator>();
        services.AddScoped<IValidator<CreateProduct>, CreateProductValidator>();
        services.AddScoped<IValidator<GetProduct>, EditProductValidator>();

        #endregion

        return services;
    }
}