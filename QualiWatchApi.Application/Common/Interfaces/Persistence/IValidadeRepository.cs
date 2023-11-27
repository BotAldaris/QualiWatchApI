using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Application.Common.Interfaces.Persistence;

public interface IValidadeRepository
{
    void AdicionarValidade(ref Produto produto);
    void DeletarValidade(ref Produto produto);
   void AtualizarValidade();
    List<Produto> GetProdutosPertoDeVencer(DateTime? ultimaAtualizacao);
}
