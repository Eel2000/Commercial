using Commercial.Application.DTOs.Category;
using Commercial.Application.Services;
using Commercial.Application.Services.Interfaces;
using Commercial.Application.Validators.Category;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Commercial.Application.Extensions;

public static class Configuration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region Services

        services.AddTransient<ICategoryService, CategoryService>();

        #endregion

        #region Validator

        services.AddScoped<IValidator<CreateCategoryDTO>, CategoryValidator>();
        services.AddScoped<IValidator<CategoryDTO>, EditCategoryValidator>();

        #endregion

        return services;
    }
}