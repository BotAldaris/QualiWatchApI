using QualiWatchApi.Domain.Model.Produtos;

namespace QualiWatchApi.Application.Common.Interfaces.Persistence;

public interface IValidadeRepository
{
   void AtualizarValidade();
    List<Produto> GetProdutosPertoDeVencer(DateTime? ultimaAtualizacao);
}
