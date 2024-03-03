using IntelliCrop.Application.Interfaces;
using IntelliCrop.Application.Services;
using IntelliCrop.Domain.Interfaces;
using IntelliCrop.Infrastructure.Context;
using IntelliCrop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntelliCrop.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("IntelliCropDb"), b =>
        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IProducerRepository, ProducerRepository>();
        services.AddScoped<IProducerService, ProducerService>();

        return services;
    }
}
