using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mttechne.Backend.Junior.Services.Data;
using Mttechne.Backend.Junior.Services.Repositories;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplications(this IServiceCollection services, IConfiguration configuration)
    {
        services
                .AddRepositories();

        services
               .AddDbContextPool<ApplicationDbContext>(opts => opts
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
               .UseSqlServer(configuration
               .GetConnectionString("SQLConnection"), b => b
               .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IProductService), typeof(ProductService));

        return services;

    }
}