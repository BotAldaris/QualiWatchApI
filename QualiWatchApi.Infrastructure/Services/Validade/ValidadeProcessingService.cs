using Microsoft.Extensions.Logging;
using QualiWatchApi.Application.Common.Interfaces.Persistence;

namespace QualiWatchApi.Infrastructure.Services.Validade;

public interface IValidadeProcessingService
{
    Task DoWork(CancellationToken stoppingToken);
}

public class ValidadeProcessingService : IValidadeProcessingService
{
    private readonly IValidadeRepository _validadeRepository;

    public ValidadeProcessingService(IValidadeRepository validadeRepository)
    {
        _validadeRepository = validadeRepository;
    }

    public async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _validadeRepository.AtualizarValidade();
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }
}