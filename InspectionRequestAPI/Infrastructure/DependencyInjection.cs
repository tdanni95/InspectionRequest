using InspectionRequestAPI.Common.Interfaces;
using InspectionRequestAPI.Infrastructure.Persistence;
using InspectionRequestAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace InspectionRequestAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<InspectionRequestDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}