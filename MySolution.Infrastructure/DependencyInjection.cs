using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySolution.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,string password)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                //builder.Configuration.GetConnectionString("DefaultConnection")+$"Password={password}")
                configuration.GetConnectionString("DefaultConnection")+$"Password={password}"));

        return services;
    }
}