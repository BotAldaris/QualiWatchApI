using QualiWatchApi.Application.Common.Interfaces.Persistence;
using QualiWatchApi.Application.Common.Interfaces.Services;
using QualiWatchApi.Domain.Model.Estatistica;

namespace QualiWatchApi.Infrastructure.Services.Estatistica;

public class EstatisticaService : IEstatisticaService
{
    private readonly IProdutoAdicionadoRepository _produtoAdicionadoRepository;
    private readonly IProdutoMonitoradoRepository _produtoMonitoradoRepository;

    public EstatisticaService(IProdutoAdicionadoRepository produtoAdicionadoRepository, IProdutoMonitoradoRepository produtoMonitoradoRepository)
    {
        _produtoAdicionadoRepository = produtoAdicionadoRepository;
        _produtoMonitoradoRepository = produtoMonitoradoRepository;
    }

    public async Task AdicionarProdutoAdicionado(ProdutoAdicionado produto)
    {
        await _produtoAdicionadoRepository.AdicionarProdutoAdicionado(produto);
    }

    public void AdicionarProdutoMonitorado(ProdutoMonitorado produto)
    {
        _produtoMonitoradoRepository.AdicionarProdutoMonitorado(produto);
    }
}
