using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Application.Common.Interfaces.Persistence;

public interface IValidadeRepository
{
    void AdicionarValidade(Produto produto);
    void DeletarValidade( Produto produto);
   void AtualizarValidade();
    List<Produto> PegarProdutosPertoDeVencer(DateTime? ultimaAtualizacao);
}
