using Commercial.Domain.Repositories.Interfaces;
using Commercial.Persistence.Contexts;
using Commercial.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commercial.Persistence.Extensions;

public static class Configure
{
    private const string CONNECTION_STRING = "default";

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING),
                mb => mb.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });

        //TODO register repositories here
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        return services;
    }
}