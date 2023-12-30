using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Application.Common.Interfaces.Persistence;

public interface IProdutoRepository
{
    Task AdicionarProduto(Produto produto);
    Task<bool> AtualizarProduto(Guid id,string? nome, string? lote, DateTime? validade);
    bool DeletarProduto(Guid id);
    List<Produto> PegarTodosOsProdutos();
    Produto? ReadProdutoById(Guid id);
    // List<Produto>? GetProdutosPertoDeVencer(HashSet<Guid> produtoIds);

}
