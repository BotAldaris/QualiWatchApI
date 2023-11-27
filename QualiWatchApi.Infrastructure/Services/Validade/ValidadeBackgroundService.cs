using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace QualiWatchApi.Infrastructure.Services.Validade;

public class ValidadeBackgroundService : BackgroundService
{

    public ValidadeBackgroundService(IServiceProvider services)
    {
        Services = services;
    }

    public IServiceProvider Services { get; }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DoWork(stoppingToken);
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {
        using (var scope = Services.CreateScope())
        {
            var scopedProcessingService = 
                scope.ServiceProvider
                    .GetRequiredService<IValidadeProcessingService>();

            await scopedProcessingService.DoWork(stoppingToken);
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await base.StopAsync(stoppingToken);
    }
}