using QualiWatchApi.Domain.Model.Estatistica;

namespace QualiWatchApi.Application.Common.Interfaces.Persistence;

public interface IProdutoAdicionadoRepository
{
    Task AdicionarProdutoAdicionado(ProdutoAdicionado produto);

    List<ProdutoAdicionado> GetAllProdutosAdicionados(DateTime? inicio, DateTime? fim);

    bool DeletarProdutoAdicionado(Guid id);

    ProdutoAdicionado? ReadProdutoById(Guid id);


}
