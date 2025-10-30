using HannahAI.Application.Common.Interfaces;
using HannahAI.Domain.Repositories;
using HannahAI.Infrastructure.Data;
using HannahAI.Infrastructure.Data.Repositories;
using HannahAI.Application.Features.Auth.Services;
using HannahAI.Infrastructure.Identity;
using HannahAI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using IUnitOfWork = HannahAI.Domain.Repositories.IUnitOfWork;


namespace HannahAI.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("HannahAI.Application")));
        services.AddAutoMapper(Assembly.Load("HannahAI.Application"));
        // Add other application services
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Switch to In-Memory Database for demonstration without SQL Server
        services.AddDbContext<HannahDbContext>(options =>
            options.UseInMemoryDatabase("HannahAiDb"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        // Register other infrastructure services
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<IFileStorageService, FileStorageService>();
        services.AddTransient<ITokenService, JwtTokenGenerator>();
        services.AddTransient<IPasswordHasher, PasswordHasher>();

        return services;
    }

    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        // Add other API-specific services
        return services;
    }
}

