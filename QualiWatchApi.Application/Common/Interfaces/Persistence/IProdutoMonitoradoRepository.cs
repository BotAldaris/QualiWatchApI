using QualiWatchApi.Domain.Model.Estatistica;

namespace QualiWatchApi.Application.Common.Interfaces.Persistence;

public interface IProdutoMonitoradoRepository
{
    void AdicionarProdutoMonitorado(ProdutoMonitorado produto);

    List<ProdutoMonitorado> GetAllProdutosMonitorados(DateTime? inicio, DateTime? fim);

    bool DeletarProdutoMonitorado(Guid id);
    ProdutoMonitorado? ReadProdutoById(Guid id);

}
