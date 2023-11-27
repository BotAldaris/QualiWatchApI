﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QualiWatchApi.Application.Common.Interfaces.Image;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.Common.Interfaces.Services;
using QualiWatchApi.Infrastructure.Image;
using QualiWatchApi.Infrastructure.Persistence;
using QualiWatchApi.Infrastructure.Persistence.Repositories;
using QualiWatchApi.Infrastructure.Services.Validade;

namespace QualiWatchApi.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.AddPersitence();
        return services;
    }
    public static IServiceCollection AddPersitence(this IServiceCollection services)
    {
        services.AddDbContext<QualiWatchApiDbContext>(options => options.UseSqlServer("Server=localhost;Database=qualiwatch;User Id=sa;Password=Aldar1s!;TrustServerCertificate=true;"));
        services.AddScoped<IValidadeRepository, ValidadeRepository>();
        services.AddScoped<IValidadeServices, ValidadeServices>();
        services.AddScoped<IProdutoRepository,ProdutoRepository>();
        services.AddSingleton<IImagemParaTexto, ImagemParaTexto>();
        services.AddHostedService<ValidadeBackgroundService>();
        services.AddScoped<IValidadeProcessingService, ValidadeProcessingService>();
        return services;
    }
}
