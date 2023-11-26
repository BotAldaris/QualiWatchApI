using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Application.Common.Interfaces.Persistence;

public interface IProdutoRepository
{
    Task Add(Produto produto);
    Task<bool> Update(Guid id,string? nome, string? lote, DateTime? validade);
    bool Delete(Guid id);
    List<Produto> Read();
    Produto? ReadProdutoById(Guid id);
    // List<Produto>? GetProdutosPertoDeVencer(HashSet<Guid> produtoIds);

}
