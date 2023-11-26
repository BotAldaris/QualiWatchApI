using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QualiWatchApi.Application.Common.Interfaces.Image;
using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Infrastructure.Image;
using QualiWatchApi.Infrastructure.Persistence;
using QualiWatchApi.Infrastructure.Persistence.Repositories;

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
        services.AddScoped<IProdutoRepository,ProdutoRepository>();
        services.AddScoped<IValidadeRepository, ValidadeRepository>();
        services.AddSingleton<IImagemParaTexto, ImagemParaTexto>();
        return services;
    }
}
