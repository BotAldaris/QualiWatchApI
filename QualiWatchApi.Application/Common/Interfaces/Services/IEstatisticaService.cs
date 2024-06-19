using QualiWatchApi.Domain.Model.Estatistica;

namespace QualiWatchApi.Application.Common.Interfaces.Services;

public interface IEstatisticaService
{
    Task AdicionarProdutoAdicionado(ProdutoAdicionado produto);
    void AdicionarProdutoMonitorado(ProdutoMonitorado produto);

}
